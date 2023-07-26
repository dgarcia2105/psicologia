using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class NegocioCreacionDTO                                                          //DTOs y AUTOMAPPER
    {
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nombre { get; set; }
    }
}
