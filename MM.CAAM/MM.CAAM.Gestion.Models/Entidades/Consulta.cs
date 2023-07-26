namespace MM.CAAM.Gestion.Models.Entidades
{
    public class Consulta                               //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]
    {
        public int Id { get; set; }
        public string MotivoConsulta { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
