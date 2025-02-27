﻿using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public string RedirectTo { get; set; }
    }
    public class AuthenticationModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
