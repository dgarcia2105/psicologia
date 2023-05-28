using System;
using MM.CAAM.Gestion.WebApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.WebApi.DTOs.Udemy
{
    public class LibroPatchDTO
    {
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        [Required]
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}

