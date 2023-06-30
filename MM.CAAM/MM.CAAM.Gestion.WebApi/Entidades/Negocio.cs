namespace MM.CAAM.Gestion.WebApi.Entidades
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
