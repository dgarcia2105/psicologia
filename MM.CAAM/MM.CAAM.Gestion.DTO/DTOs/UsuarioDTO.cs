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

        public int RolId { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Telefono { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Password { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string ConfirmarPassword { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string NombrePerfil { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
        public int GeneroId { get; set; }
        public bool Activo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string PerfilNombreArchivo { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Profesion { get; set; }

        //[StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        //public string Calle { get; set; }

        //[StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        //public string Numero { get; set; }

        //[StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        //public string Colonia { get; set; }

        //[StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        //public string CP { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Municipio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaAcceso { get; set; }
        public string BearerToken { get; set; }
        public List<NegocioDTO> Negocios { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Nacionalidad { get; set; }
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Ocupacion { get; set; }

        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Direccion { get; set; }
        public string Usuario { get; set; }

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

            //    if (tiempoTranscurrido.TotalDays > 1)
            //    tiempoEspera = $"{tiempoTranscurrido:dd' días'}";
            //else if (tiempoTranscurrido.TotalDays == 1)
            //    tiempoEspera = $"{tiempoTranscurrido:dd' día'}";
            //else if (tiempoTranscurrido.TotalHours >= 1)
            //    tiempoEspera = $"{tiempoTranscurrido:hh\\:mm' Hrs.'}";
            //else
            //    tiempoEspera = $"{tiempoTranscurrido:mm' Min.'}";

            //return tiempoEspera;
        }
    }
}

