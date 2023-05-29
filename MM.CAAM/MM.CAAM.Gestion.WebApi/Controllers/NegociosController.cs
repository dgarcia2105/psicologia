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

namespace MM.CAAM.Gestion.WebApi.Controllers    
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
        public async Task<ActionResult<Negocio>> Get(int id)
        {
            var negocio = await context.Negocios.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
            return negocio;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Negocio negocio)
        {
            var existeNegocio = await context.Usuarios.AnyAsync(x => x.Id == negocio.UsuarioId);

            if(!existeNegocio)
            {
                return BadRequest($"No existe el usuario de Id: {negocio.UsuarioId}");
            }

            context.Add(negocio);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}

