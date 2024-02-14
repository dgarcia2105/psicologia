using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MM.CAAM.Gestion.Models.Entidades.Udemy;
using MM.CAAM.Gestion.Models.Validaciones;

namespace MM.CAAM.Gestion.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoMaterno { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Telefono { get; set; }

        //[StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Password { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? NombrePerfil { get; set; }
        [StringLength(maximumLength: 240, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Notas { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaNacimiento { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? PerfilNombreArchivo { get; set; }

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
        public string? AntecedentesHeredofamiliares { get; set; }
        public string? AntecedentesPatologicosPersonales { get; set; }
        public string? AntecedentesNoPatologicos { get; set; }
        public string? Religion { get; set; }
        public string? GrupoSanguineo { get; set; }
        public string? RecomendadoPor { get; set; }
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

        public Rol Rol { get; set; }
        public Genero Genero { get; set; } 
        public GradoEducacion GradoEducacion { get; set; }
        public EstadoVida EstadoVida { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        #endregion

        public List<UsuarioNegocio> UsuariosNegocios { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
