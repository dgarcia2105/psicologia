namespace MM.CAAM.Gestion.Models.Entidades
{
    public class Consulta                               //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]
    {
        public int Id { get; set; }
        public string? PresionArterial { get; set; }
        public string? Temperatura { get; set; }
        public string? FrecuenciaCardiaca { get; set; }
        public string? FrecuenciaRespiratoria { get; set; }
        public string? ComentarioSignosVitales { get; set; }
        public string MotivoConsulta { get; set; }
        public string? PadecimientoActual { get; set; }
        public string? ExploracionFisica { get; set; }
        public string? Diagnostico { get; set; }
        public string? TratamientoMedico { get; set; }
        public string? EstudiosSolicitadosLaboratorioGabinete { get; set; }
        public string? CartaBajoConsentimientoInformado { get; set; }
        public string? NotasEvolucion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
