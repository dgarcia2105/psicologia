using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Models.Filtros;
using MM.CAAM.Gestion.DTO.DTOs;
using System.Linq;
using MM.CAAM.Gestion.Models.Entidades.Udemy;

namespace MM.CAAM.Gestion.Models.Controllers    
{
    [ApiController]                                                             //si algo sale mal retorna un bad request
    [Route("api/negocios")]
    //[Authorize]
    public class NegociosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public NegociosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NegocioDTO>> Get(int id)
        {
            var negocio = await context.Negocios.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<NegocioDTO>(negocio);
        }

        [HttpPost]
        public async Task<ActionResult> Post(NegocioCreacionDTO negocioCreacionDTO)
        {
            //var existeNegocio = await context.Usuarios.AnyAsync(x => x.Id == negocio.UsuarioId);

            //if(!existeNegocio)
            //{
            //    return BadRequest($"No existe el usuario de Id: {negocio.UsuarioId}");
            //}

            var negocio = mapper.Map<Negocio>(negocioCreacionDTO);

            context.Add(negocio);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

