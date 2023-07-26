using MM.CAAM.Gestion.WebApi.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

