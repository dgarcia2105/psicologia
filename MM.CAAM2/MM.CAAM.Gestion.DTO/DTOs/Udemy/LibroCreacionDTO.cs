using System;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.Models.Validaciones;

namespace MM.CAAM.Gestion.DTO.DTOs.Udemy
{
    public class LibroCreacionDTO
    {
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        [Required]
        public string Titulo { get; set; }
        public DateTime FechaPublicaciom { get; set; }
        public List<int> AutoresIds { get; set; }
    }
}

