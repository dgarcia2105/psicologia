﻿using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.WebApi.Filtros;
using System.Linq;
using MM.CAAM.Gestion.WebApi.Entidades.Udemy;
using MM.CAAM.Gestion.WebApi.DTOs.Udemy;

namespace MM.CAAM.Gestion.WebApi.Controllers.Udemy
{
    [ApiController]                                                             //si algo sale mal retorna un bad request
    [Route("api/autores")]
    //[Authorize]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] // api/autores
        public async Task<List<AutorDTO>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpGet("{id:int}", Name = "ObtenerAutor")]
        public async Task<ActionResult<AutorDTOConLibros>> Get(int id)
        {
            var autor = await context.Autores
                .Include(autorDB => autorDB.AutoresLibros)
                .ThenInclude(autorLibroDB => autorLibroDB.Libro)
                .FirstOrDefaultAsync(AutorBD => AutorBD.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTOConLibros>(autor);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string nombre)
        {
            var autores = await context.Autores.Where(AutorBd => AutorBd.Nombre.Contains(nombre)).ToListAsync();



            return mapper.Map<List<AutorDTO>>(autores);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDto)
        {
            var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Nombre == autorCreacionDto.Nombre);

            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autorCreacionDto.Nombre}");
            }

            var autor = mapper.Map<Autor>(autorCreacionDto);

            context.Add(autor);
            await context.SaveChangesAsync();

            var autorDto = mapper.Map<AutorDTO>(autor);

            return CreatedAtRoute("ObtenerAutor", new { id = autor.Id }, autorDto);
        }

        //EJEMPLO POST LIST
        [HttpPost("post_list")]
        public async Task<ActionResult> Post([FromBody] List<AutorCreacionDTO> listAautorCreacionDto)
        {
            //var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Nombre == autorCreacionDto.Nombre);

            //if (existeAutorConElMismoNombre)
            //{
            //    return BadRequest($"Ya existe un autor con el nombre {autorCreacionDto.Nombre}");
            //}

            //var autor = mapper.Map<Autor>(autorCreacionDto);

            //context.Add(autor);
            //await context.SaveChangesAsync();

            //var autorDto = mapper.Map<AutorDTO>(autor);

            //return CreatedAtRoute("ObtenerAutor", new { id = autor.Id }, autorDto);

            return null;
        }

        /*
           [
                {
                  "nombre": "test list 1"
                },
                {
                  "nombre": "test list 2"
                }
           ]
        */

        [HttpPut("{id:int}")] // api/autores/1 
        public async Task<ActionResult> Put(AutorCreacionDTO autorCreacionDTO, int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var autor = mapper.Map<Autor>(autorCreacionDTO);
            autor.Id = id;

            context.Update(autor);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")] // api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
