
using MM.CAAM.Gestion.Models.Entidades;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class CatalogoDTO
    {
        public List<Rol> ListRol { get; set; }
        public List<Genero> ListGenero { get; set; }
        public List<GradoEducacion> ListGradoEducacion { get; set; }
        public List<EstadoVida> ListEstadoVida { get; set; }
        public List<EstadoCivil> ListEstadoCivil { get; set; }
        public List<TipoUsuario> ListTipoUsuario { get; set; }
    }
}
