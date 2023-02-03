using System;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.WebApi.Validaciones;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
	public class LibroCreacionDTO
	{
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        public string Titulo { get; set; }
	}
}

