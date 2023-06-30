using System;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.WebApi.Validaciones;

namespace MM.CAAM.Gestion.WebApi.DTOs.Udemy
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

