﻿namespace BookStore.Shared.Models
{
    public class AuthModel
    {
        public string? Message { get; set; }
        public string? Token { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string> Roles { get; set; } = new();
        public bool IsAuthenticated { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string? UserId { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
