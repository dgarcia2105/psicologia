using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MM.CAAM.Gestion.DTO.DTOs
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
        [StringLength(maximumLength: 240, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Notas { get; set; }


        [DataType(DataType.EmailAddress)]
        [StringLength(60, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Correo Electrónico")]
        public string? Correo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Telefono { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Password { get; set; }

        [JsonIgnore]
        public string? ConfirmarPassword { get; set; }

        [StringLength(25, ErrorMessage = "Máximo {1} caracteres.")]
        [Display(Name = "Usuario")]
        public string? NombrePerfil { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaNacimiento { get; set; }

        [DataType(DataType.Upload)]
        public string? PerfilNombreArchivo { get; set; }

        public string? PathImagenPerfil { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Profesion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Nacionalidad { get; set; }
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Ocupacion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Direccion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Calle { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Numero { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Colonia { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? CP { get; set; }
        public bool? Activo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Municipio { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }

        [Display(Name = "Antecedentes Heredofamiliares")]
        public string? AntecedentesHeredofamiliares { get; set; }

        [Display(Name = "Antecedentes Patologicos Personales")]
        public string? AntecedentesPatologicosPersonales { get; set; }

        [Display(Name = "Antecedentes No Patológicos")]
        public string? AntecedentesNoPatologicos { get; set; }

        [Display(Name = "Religión")]
        public string? Religion { get; set; }

        [Display(Name = "Grupo Sanguineo")]
        public string? GrupoSanguineo { get; set; }

        [Display(Name = "Recomendado Por")]
        public string? RecomendadoPor { get; set; }

        [Display(Name = "Seguro Médico")]
        public string? SeguroMedico { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaAcceso { get; set; }
        public string? BearerToken { get; set; }

        #region CATALOGOS
        public int? RolId { get; set; }
        public int? GeneroId { get; set; }
        public int? GradoEducacionId { get; set; }
        public int? EstadoVidaId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int? TipoUsuarioId { get; set; }
        #endregion
    }
}
