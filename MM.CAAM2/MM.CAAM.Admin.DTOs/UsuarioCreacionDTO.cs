
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Admin.DTOs
{
    public class UsuarioCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoMaterno { get; set; }

        //[Required(ErrorMessage = "* Obligatorio")]
        [StringLength(25, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Usuario")]
        public string NombrePerfil { get; set; }

        //[Required(ErrorMessage = "* Obligatorio")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }
    }
}
