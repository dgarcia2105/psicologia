using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public int Position { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido Paterno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoPaterno { get; set; }

        [DisplayName("Apellido Materno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ApellidoMaterno { get; set; }

        [DisplayName("Notas")]
        [StringLength(maximumLength: 240, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Notas { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Telefono { get; set; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Password { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ConfirmarPassword { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string NombrePerfil { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Imagén Perfil")]
        public string PerfilNombreArchivo { get; set; }

        public string PathImagenPerfil { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Profesion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nacionalidad { get; set; }
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Ocupacion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Direccion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Calle { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Numero { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? Colonia { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string? CP { get; set; }
        public bool Activo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Municipio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

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
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaAcceso { get; set; }
        public string BearerToken { get; set; }

        #region CATALOGOS
        public int RolId { get; set; }
        public int GeneroId { get; set; }
        public int GradoEducacionId { get; set; }
        public int EstadoVidaId { get; set; }
        public int EstadoCivilId { get; set; }
        public int TipoUsuarioId { get; set; }
        public Rol Rol { get; set; }
        public Genero Genero { get; set; }
        public GradoEducacion GradoEducacion { get; set; }
        public EstadoVida EstadoVida { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        #endregion

        #region COMPUTED
        public string NombreCompleto
        {
            get
            {
                return $"{Nombre}" +
                    $"{(string.IsNullOrWhiteSpace(ApellidoPaterno) ? "" : $" {ApellidoPaterno}")}"+
                    $"{(string.IsNullOrWhiteSpace(ApellidoMaterno) ? "" : $" {ApellidoMaterno}")}";
            }
        }
        public string TiempoNacimiento
        {
            get
            {
                var dias = GetCreadoHace(FechaNacimiento);
                return dias;
            }
        }
        private string GetCreadoHace(DateTime FechaNacimiento)
        {
            var nowDate = Com.GetUtcNowByZone();
            var tiempoTranscurrido = (nowDate - FechaNacimiento);
            string tiempoEspera;

            DateTime thisDay = DateTime.Today;
            TimeSpan age = thisDay - FechaNacimiento;
            DateTime totalTime = new DateTime(age.Ticks);

            var creadoHace = string.Empty;

            var years = totalTime.Year - 1;
            var months = totalTime.Month - 1;
            var textoAnios = string.Empty;
            var textoMeses = string.Empty;
            if (years > 0) { 
                textoAnios = years > 1 ? $"{years} años" : $"{years} año" ;
            }
            if (months > 0)
            {
                textoMeses = months > 1 ? $"{months} meses" : $"{months} mes";
            }

            return $"{textoAnios} {textoMeses}"; 
        }
        #endregion
    }
}

