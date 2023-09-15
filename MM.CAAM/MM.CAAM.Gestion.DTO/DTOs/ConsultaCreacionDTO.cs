using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class ConsultaCreacionDTO                                                          //DTOs y AUTOMAPPER
    {
        [Display(Name = "Presión Arterial")]
        public string? PresionArterial { get; set; }

        [Display(Name = "Temperatura")]
        public string? Temperatura { get; set; }

        [Display(Name = "Frecuencia Cardíaca")]
        public string? FrecuenciaCardiaca { get; set; }

        [Display(Name = "Frecuencia Respiratoria")]
        public string? FrecuenciaRespiratoria { get; set; }

        [Display(Name = "Comentario de los Signos Vitales")]
        public string? ComentarioSignosVitales { get; set; }

        [Display(Name = "Motivo de la Consulta")]
        public string MotivoConsulta { get; set; }

        [Display(Name = "Padecimiento Actual (Interrogatorio)")]
        public string? PadecimientoActual { get; set; }

        [Display(Name = "Exploración Física")]
        public string? ExploracionFisica { get; set; }

        [Display(Name = "Diagnóstico")]
        public string? Diagnostico { get; set; }

        [Display(Name = "Tratamiento Médico")]
        public string? TratamientoMedico { get; set; }

        [Display(Name = "Estudios Solicitados de Laboratorio y Gabinete")]
        public string? EstudiosSolicitadosLaboratorioGabinete { get; set; }

        [Display(Name = "Carta Bajo Consentimiento Informado")]
        public string? CartaBajoConsentimientoInformado { get; set; }

        [Display(Name = "Notas de Evolución")]
        public string? NotasEvolucion { get; set; }

        [Display(Name = "Saturación de oxígeno")]
        public string? SaturacionOxigeno { get; set; }
    }
}
