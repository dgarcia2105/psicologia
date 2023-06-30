using MM.CAAM.Gestion.WebApi.Entidades;
using System;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class UsuarioDTO 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<NegocioDTO> Negocios { get; set; } //= new List<Negocio>();
        public List<ConsultaDTO> Consultas { get; set; }

        /*
         * Comentando propiedades, y quitando includes se puede manejar algo llamado lazy-loading
         */
    }
}

