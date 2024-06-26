﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.RazorPages.Models;

public class AuthenticateModel
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}