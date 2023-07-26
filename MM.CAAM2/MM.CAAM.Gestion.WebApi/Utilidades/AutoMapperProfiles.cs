using System;
using AutoMapper;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Catalogos;
using MM.CAAM.Gestion.DTO.DTOs.Udemy;
using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Models.Entidades.Catalogos;
using MM.CAAM.Gestion.Models.Entidades.Udemy;

namespace MM.CAAM.Gestion.Models.Utilidades
{
    public class AutoMapperProfiles: Profile                                                    //DTOs y AUTOMAPPER
    {
		public AutoMapperProfiles()
        {
            #region UDEMY
            CreateMap<AutorCreacionDTO, Autor>();

            CreateMap<Autor, AutorDTO>();
            CreateMap<Autor, AutorDTOConLibros>()
                .ForMember(autorDTO => autorDTO.Libros, opciones => opciones.MapFrom(MapAutorDTOLibros));
            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(libro => libro.AutoresLibros, opciones => opciones.MapFrom(MapAutoresLibros));
            CreateMap<Libro, LibroDTO>();
            CreateMap<Libro, LibroDTOConAutores>()
                .ForMember(libroDTO => libroDTO.Autores, opciones => opciones.MapFrom(MapLibroDTOAutores));
            CreateMap<LibroPatchDTO, Libro>().ReverseMap();

            CreateMap<ComentarioCreacionDTO, Comentario>();
            CreateMap<Comentario, ComentarioDTO>();
            #endregion

            //Fuente y el destino
            CreateMap<UsuarioCreacionDTO, Usuario>();                                           //FUENTE y DESTINO
            CreateMap<Usuario, UsuarioDTO>();                                                   //FUENTE y DESTINO
            CreateMap<NegocioCreacionDTO, Negocio>();
            CreateMap<Negocio, NegocioDTO>();
            CreateMap<ConsultaCreacionDTO,  Consulta>();
            CreateMap<Consulta, ConsultaDTO>();

            #region CATALOGOS - TIPOS
            CreateMap<CatalogoCreacionDTO, GrupoAlimenticio>();
            CreateMap<CatalogoCreacionDTO, Proveedor>();
            CreateMap<CatalogoCreacionDTO, SeccionSupermercado>();
            CreateMap<CatalogoCreacionDTO, TipoGrupo>();
            CreateMap<CatalogoCreacionDTO, UnidadMedida>();
            #endregion
        }

        private List<LibroDTO> MapAutorDTOLibros(Autor autor, AutorDTO autorDTO)
        {
            var resultado = new List<LibroDTO>();

            if(autor.AutoresLibros == null) { return resultado; }

            foreach(var autorLibro in autor.AutoresLibros)
            {
                resultado.Add(new LibroDTO()
                {
                    Id = autorLibro.LibroId,
                    Titulo = autorLibro.Libro.Titulo 
                });
            }

            return resultado;
        }
         
        private List<AutorDTO> MapLibroDTOAutores(Libro libro, LibroDTO libroDTO)
        {
            var resultado = new List<AutorDTO>();

            if(libro.AutoresLibros == null) { return resultado; }

            foreach(var autorLibro in libro.AutoresLibros)
            {
                resultado.Add(new AutorDTO()
                {
                    Id = autorLibro.AutorId,
                    Nombre = autorLibro.Autor.Nombre
                });
            }

            return resultado;
        }

        private List<AutorLibro> MapAutoresLibros(LibroCreacionDTO libroCreacionDTO, Libro libro)
        {
            var resultado = new List<AutorLibro>();

            if(libroCreacionDTO.AutoresIds == null) { return resultado; }

            foreach(var autorId in libroCreacionDTO.AutoresIds)
            {
                resultado.Add(new AutorLibro() { AutorId = autorId });
            }

            return resultado;
        }
	}
}

