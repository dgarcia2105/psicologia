 
namespace MM.CAAM.Gestion.Models.Entidades
{
    public class UsuarioNegocio
    {
        public int UsuarioId { get; set; }
        public int NegocioId { get; set; }
        public int Order { get; set; }
        public Usuario Usuario { get; set; }
        public Negocio Negocio { get; set; }

    }
}
