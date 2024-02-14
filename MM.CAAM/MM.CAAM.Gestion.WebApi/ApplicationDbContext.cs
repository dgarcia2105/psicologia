using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Models.Entidades.Catalogos;
using MM.CAAM.Gestion.Models.Entidades.Udemy;

namespace MM.CAAM.Gestion.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region LLaves_Primarias_Compuestas
            modelBuilder.Entity<AutorLibro>()
                .HasKey(al => new { al.AutorId, al.LibroId });

            modelBuilder.Entity<UsuarioNegocio>()
                .HasKey(al => new { al.UsuarioId, al.NegocioId });
            #endregion
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<GradoEducacion> GradoEducacion { get; set; }
        public DbSet<EstadoVida> EstadoVida { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<UsuarioNegocio> UsuariosNegocios { get; set; }

        #region TIPOS-CATALOGOS

        public DbSet<GrupoAlimenticio> GrupoAlimenticios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<SeccionSupermercado> SeccionesSupermercado { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<TipoGrupo> TiposGrupo { get; set; }

        #endregion

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

        //Add-Migration Inicial                                             //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]
        //    Update-Database
    }
}