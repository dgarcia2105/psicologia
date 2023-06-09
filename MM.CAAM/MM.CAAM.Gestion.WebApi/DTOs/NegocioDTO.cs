using MM.CAAM.Gestion.WebApi.Entidades;
using System;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class NegocioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}

