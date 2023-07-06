
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MM.CAAM.Admin.DTOs
{
    public class RolDTO
    {

        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Rol")]
        public int RolId { get; set; }
        
        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(25, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(7, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "No. Empleado")]
        public string Empno { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [StringLength(25, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [StringLength(13, ErrorMessage = "La contraseña debe contener de 4 a 13 caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* Obligatorio")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Password), ErrorMessage = "Las contraseñas no son iguales.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string VerificationCode { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Imagén Perfil")]
        public string PerfilNombreArchivo { get; set; }

        [Display(Name = "¿Esta Activo?")]
        public bool Activo { get; set; }
        public string BearerToken { get; set; }
        public RolDto Rol { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombres}{(string.IsNullOrWhiteSpace(Apellidos) ? "" : $" {Apellidos}")}";
            }
        }
        public string EstaActivo
        {
            get
            {
                return Activo ? "Si" : "No";
            }
        }

    }
}
