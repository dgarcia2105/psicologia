namespace MM.CAAM.Gestion.Models.Entidades
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<UsuarioNegocio> UsuariosNegocios { get; set; }
    }
}
