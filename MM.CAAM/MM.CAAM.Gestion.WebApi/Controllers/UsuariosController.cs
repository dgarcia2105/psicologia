using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.WebApi.Entidades;
using MM.CAAM.Gestion.WebApi.Filtros;
using MM.CAAM.Gestion.WebApi.DTOs;
using System.Linq;
using MM.CAAM.Gestion.WebApi.Entidades.Udemy;
using MM.CAAM.Gestion.WebApi.DTOs.Udemy;

namespace MM.CAAM.Gestion.WebApi.Controllers    
{
    [ApiController]                                                             //si algo sale mal retorna un bad request
    [Route("api/usuarios")]
    //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.Include(x => x.Negocios).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var existeUsuarioConElMismoNombre = await context.Usuarios.AnyAsync(x =>  x.Nombre.Equals(usuarioCreacionDTO.Nombre));

            if(existeUsuarioConElMismoNombre) 
            {
                return BadRequest($"Ya existe un usuario con el nombre {usuarioCreacionDTO.Nombre}");
            }

            //Esto funciona pero es mejor el automapper
            //var usuario = new Usuario()
            //{
            //    Nombre = usuarioCreacionDTO.Nombre
            //};

            var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);

            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]   //api/usuarios/1
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            //-- Validación sin DTO
            if(usuario.Id != id) 
            {
                return BadRequest("El id del usuario no coincide con el id de la URL");
            }

            var existe = await context.Usuarios.AnyAsync(us => us.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(usuario);
            await context.SaveChangesAsync();
            return Ok();

            //-----------------------------------------------------------------

            //var existe = await context.Autores.AnyAsync(x => x.Id == id);

            //if (!existe)
            //{
            //    return NotFound();
            //}

            //var autor = mapper.Map<Autor>(autorCreacionDTO);
            //autor.Id = id;

            //context.Update(autor);
            //await context.SaveChangesAsync();
            //return NoContent();
        }

        [HttpDelete("{id:int}")]    //api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(us => us.Id == id);

            if (!existe)
            {
                return NotFound();
            }
            
            context.Remove(new Usuario { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

