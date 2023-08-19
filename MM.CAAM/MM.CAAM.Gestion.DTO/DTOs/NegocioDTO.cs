using MM.CAAM.Gestion.Models.Entidades;
using System;

namespace MM.CAAM.Gestion.DTO.DTOs
{
    public class NegocioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; }
    }
}

