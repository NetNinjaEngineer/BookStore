﻿using BookStore.Application.Contracts.Identity;
using BookStore.Application.Contracts.Infrastructure;
using BookStore.Identity.Models;
using BookStore.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Identity.Services;

public sealed class AuthService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IConfiguration configuration,
    IHttpContextAccessor contextAccessor,
    IEmailSender emailSender,
    LinkGenerator linkGenerator) : IAuthService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly IEmailSender _emailSender = emailSender;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly LinkGenerator _linkGenerator = linkGenerator;


    public async Task<(bool confirmed, string message)> ConfirmEmailAsync(ConfirmEmailModel confirmModel)
    {
        var user = await _userManager.FindByIdAsync(confirmModel.UserId!);

        if (user == null)
            return (false, $"There is no user with ID: ${confirmModel.UserId}");

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return (true, "Email confirmed successfully.");

        return (false, result.Errors.Select(e => e.Description).ToString()!);

    }

    public async Task<string> GeneratePasswordResetToken(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user is not null)
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        return null!;
    }

    public async Task<UserInfoModel> GetCurrentUserInformation(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
            return null!;
        var roles = await _userManager.GetRolesAsync(user);

        var userInfo = new UserInfoModel()
        {
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NormalizedEmail = user.NormalizedEmail,
            PhoneNumber = user.PhoneNumber,
            UserRoles = [.. roles]
        };

        return userInfo;

    }

    public async Task<AuthModel> GetTokenRequestModelAsync(TokenRequestModel model)
    {
        var authModel = new AuthModel();

        var user = await _userManager.FindByEmailAsync(model.Email!);
        if (user == null)
        {
            authModel.Message = "Invalid email or password";
            authModel.IsAuthenticated = false;
            return authModel;
        }

        if (await _userManager.IsLockedOutAsync(user))
        {
            authModel.Message = "User is locked out";
            return authModel;
        }

        if (!await _userManager.CheckPasswordAsync(user, model.Password!))
        {
            authModel.Message = "Invalid email or password";
            authModel.IsAuthenticated = false;
            return authModel;
        }

        if (!user.EmailConfirmed)
        {
            authModel.Message = "Confirm your email, then try again!";
            authModel.IsAuthenticated = false;
            return authModel;
        }

        var securityJwtToken = await CreateJwtToken(user);
        var userRoles = await _userManager.GetRolesAsync(user);

        authModel.IsAuthenticated = true;
        authModel.UserName = user.UserName;
        authModel.Roles = [.. userRoles];
        authModel.ExpiresOn = securityJwtToken.ValidTo;
        authModel.Email = model.Email;
        authModel.UserName = user.UserName;
        authModel.UserId = user.Id;
        authModel.Token = new JwtSecurityTokenHandler().WriteToken(securityJwtToken);
        authModel.IsEmailConfirmed = user.EmailConfirmed;
        authModel.UserId = user.Id;

        return authModel;
    }

    public async Task<AuthModel> RegisterAsync(RegisterModel requestModel)
    {
        if (await _userManager.FindByEmailAsync(requestModel.Email!) is not null)
            return new AuthModel { Message = "Email is already registered!" };

        if (await _userManager.FindByNameAsync(requestModel.Username!) is not null)
            return new AuthModel { Message = "Username is already registered !" };

        var user = new ApplicationUser
        {
            UserName = requestModel.Username,
            Email = requestModel.Email,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName
        };

        var result = await _userManager.CreateAsync(user, requestModel.Password!);

        if (!result.Succeeded)
        {
            var errors = string.Empty;

            foreach (var error in result.Errors)
            {
                errors += error.Description;
            }

            return new AuthModel { Message = errors };
        }

        await _userManager.AddToRoleAsync(user, "User");

        var jwtSecurityToken = await CreateJwtToken(user);

        return new AuthModel
        {
            Email = user.Email,
            IsAuthenticated = true,
            ExpiresOn = jwtSecurityToken.ValidTo,
            Roles = ["User"],
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            UserName = user.UserName,
            UserId = user.Id,
            IsEmailConfirmed = user.EmailConfirmed
        };
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email!);
        if (user == null) return false;

        var result = await _userManager.ResetPasswordAsync(user, model.Token!, model.NewPassword!);
        return result.Succeeded;
    }

    public async Task<bool> SendPasswordResetEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return false;
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var callbackUrl = _linkGenerator.GetUriByAction(_contextAccessor.HttpContext!, "ResetPassword", "Auth", new { token, email = user.Email });
        var emailBody = $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.";

        return await _emailSender.SendEmailAsync(user.Email!, "Reset Password", emailBody);

    }

    public async Task SignOutAsync() => await _signInManager.SignOutAsync();

    public async Task<(bool, string)> UpdateUserInfoAsync(UpdateUserInfoModel model)
    {
        var userId = _contextAccessor.HttpContext?.User.FindFirstValue("uid");
        var user = await _userManager.FindByIdAsync(userId!);
        if (user == null)
            return (false, "Invalid user id.");

        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return (false, result.Errors.Select(e => e.Description).ToString()!);

        return (true, "User information Updated successfully");
    }

    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim(ClaimTypes.Role, role));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

        var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:ValidIssuer"],
            audience: _configuration["JwtSettings:ValidAudience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }
}
