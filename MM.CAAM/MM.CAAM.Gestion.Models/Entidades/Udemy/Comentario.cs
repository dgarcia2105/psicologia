using Microsoft.AspNetCore.Identity;
using System;

namespace MM.CAAM.Gestion.Models.Entidades.Udemy
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int LibroId { get; set; }
        public Libro libro { get; set; }
        public string UsuarioId { get; set;}
        public IdentityUser Usuario { get; set; }

    }
}

