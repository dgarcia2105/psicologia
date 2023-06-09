using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.WebApi.DTOs;
using MM.CAAM.Gestion.WebApi.Entidades;

namespace MM.CAAM.Gestion.WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios/{usuarioId:int}/consultas")]             //CONTROLADOR DE UN RECURSO DEPENDIENTE
    public class ConsultasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ConsultasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultaDTO>>> Get(int usuarioId)
        {
            var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);

            if (!existeUsuario)
            {
                return NotFound();
            }

            var consultas = await context.Consultas
                .Where(consultasDB => consultasDB.UsuarioId == usuarioId).ToListAsync();
            return mapper.Map<List<ConsultaDTO>>(consultas);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int usuarioId, ConsultaCreacionDTO consultaCreacionDTO)
        {
            var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);
            
            if (!existeUsuario)
            {
                return NotFound();
            }

            var consulta = mapper.Map<Consulta>(consultaCreacionDTO);
            consulta.UsuarioId = usuarioId;
            context.Add(consulta);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
