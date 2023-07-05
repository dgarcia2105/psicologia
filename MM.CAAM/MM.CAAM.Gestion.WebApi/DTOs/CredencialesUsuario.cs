﻿using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
