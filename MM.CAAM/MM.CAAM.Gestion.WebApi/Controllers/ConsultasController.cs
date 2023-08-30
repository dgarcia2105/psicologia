using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Udemy;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Models.Migrations;
using MM.CAAM.Gestion.Services.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.Models.Controllers
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

        [HttpGet("ObtenerConsultas")]
        public async Task<ActionResult<List<ConsultaDTO>>> Get()
        {
            try
            {
                #region
                var consultas = await context.Consultas 
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
                var data = mapper.Map<List<ConsultaDTO>>(consultas);
                #endregion

                return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            }

        }
        [HttpGet]
        public async Task<ActionResult<List<ConsultaDTO>>> Get(int usuarioId)
        {
            try
            {
                #region
                var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);

                if (!existeUsuario)
                {
                    throw new ArgumentException($"No existe el usuarioId: {usuarioId}");
                }

                var consultas = await context.Consultas
                    .Where(consultasDB => consultasDB.UsuarioId == usuarioId)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
                var data = mapper.Map<List<ConsultaDTO>>(consultas);
                #endregion

                return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            }

        }

        [HttpGet("{id:int}", Name = "ObtenerConsulta")]
        public async Task<ActionResult<ConsultaDTO>> GetPorId(int id)
        {
            try { 
                var consulta = await context.Consultas.Include(u => u.Usuario).FirstOrDefaultAsync(consultaDB => consultaDB.Id == id);

                if (consulta == null)
                {
                    throw new ArgumentException($"No existe la consultaId: {id}");
                }

                var data =  mapper.Map<ConsultaDTO>(consulta);
                return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(int usuarioId, ConsultaCreacionDTO consultaCreacionDTO)
        {
            try
            {
                var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);

                if (!existeUsuario)
                {
                    throw new ArgumentException($"No existe el usuarioId: {usuarioId}");
                }

                var consulta = mapper.Map<Consulta>(consultaCreacionDTO);
                consulta.UsuarioId = usuarioId;
                context.Add(consulta);
                await context.SaveChangesAsync();
                return Ok(new Result { Code = StatusCodes.Status200OK });
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            }
        }
    }
}
