using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
