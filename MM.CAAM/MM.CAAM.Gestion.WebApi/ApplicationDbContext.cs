using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using MM.CAAM.Gestion.WebApi.Entidades;
using MM.CAAM.Gestion.WebApi.Entidades.Catalogos;
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
        public DbSet<Consulta> Consultas { get; set; }                      //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]

        #region TIPOS-CATALOGOS

        public DbSet<GrupoAlimenticio> GrupoAlimenticios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<SeccionSupermercado> SeccionesSupermercado { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<TipoGrupo> TiposGrupo { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }

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