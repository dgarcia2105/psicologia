using MM.CAAM.Gestion.Models.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

