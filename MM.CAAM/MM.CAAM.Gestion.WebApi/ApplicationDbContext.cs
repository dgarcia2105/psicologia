using System;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.WebApi.Entidades;
using MM.CAAM.Gestion.WebApi.Entidades.Udemy;

namespace MM.CAAM.Gestion.WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorLibro>()
                .HasKey(al => new { al.AutorId, al.LibroId });
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Negocio> Negocios { get; set; }

        #region UDEMY
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; }
        #endregion

        /*
        * dotnet ef migrations add Comentarios
        * dotnet ef database update
        */
    }
}