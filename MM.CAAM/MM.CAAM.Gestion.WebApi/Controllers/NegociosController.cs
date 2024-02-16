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
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Services.Exceptions;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.Models.Migrations;

namespace MM.CAAM.Gestion.Models.Controllers    
{
    [ApiExplorerSettings(IgnoreApi = true)]
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


        [HttpGet]
        public async Task<ActionResult<List<NegocioDTO>>> Get()
        {
            //try
            //{
            //    var negocios = await context.Negocios
            //        //.Include(negocioDB => negocioDB.UsuariosNegocios)
            //        //.ThenInclude(usuarioLibroDB => usuarioLibroDB.Usuario)
            //        .OrderByDescending(n => n.Id).ToListAsync();
            //    foreach (var negocio in negocios)
            //    {
            //        negocio.UsuariosNegocios = negocio.UsuariosNegocios.OrderBy(x => x.Order).ToList();
            //    }

            //    var data = mapper.Map<List<NegocioDTO>>(negocios);

            //    return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
            //}
            //catch (ValidationException ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            //}
            //catch (Exception ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            //}

            return null;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NegocioDTO>> Get(int id)
        {
            //try { 
            //    var negocio = await context.Negocios
            //        .Include(negocioDB => negocioDB.UsuariosNegocios)
            //        .ThenInclude(usuarioLibroDB => usuarioLibroDB.Usuario)
            //        .FirstOrDefaultAsync(x => x.Id == id); 

            //    negocio.UsuariosNegocios = negocio.UsuariosNegocios.OrderBy(x => x.Order).ToList();

            //    var data = mapper.Map<NegocioDTO>(negocio);
            //    return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
            //}
            //catch (ValidationException ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            //}
            //catch (Exception ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            //}

            return null;
        }

        [HttpPost]
        public async Task<ActionResult> Post(NegocioCreacionDTO negocioCreacionDTO)
        {
            //try {
            //    #region 

            //    var usuariosIds = await context.Usuarios
            //        .Where(usuarioBD => negocioCreacionDTO.UsuariosIds.Contains(usuarioBD.Id)).Select(x => x.Id).ToListAsync();

            //    if(negocioCreacionDTO.UsuariosIds.Count != usuariosIds.Count)
            //    {
            //        throw new ArgumentException($"No existe alguno de los usuarios enviados");
            //    }

            //    var nombreNegocio = negocioCreacionDTO.Nombre;

            //    if (string.IsNullOrEmpty(nombreNegocio))
            //    {
            //        throw new ArgumentException($"Nombre del negocio no puede estar vacío");
            //    }

            //    var existeNegocio = await context.Negocios.AnyAsync(x => x.Nombre.Equals(nombreNegocio));

            //    if (existeNegocio)
            //    {
            //        throw new ArgumentException($"El nombre del negocio {nombreNegocio} ya esta en uso");
            //    }

            //    var negocio = mapper.Map<Negocio>(negocioCreacionDTO);

            //    if (negocio != null)
            //    {
            //        for(int i=0; i < negocio.UsuariosNegocios.Count; i++)
            //        {
            //            negocio.UsuariosNegocios[i].Order = i;
            //        }
            //    }

            //    context.Add(negocio);
            //    await context.SaveChangesAsync();
            //    #endregion

            //    return Ok(new Result { Code = StatusCodes.Status200OK });
            //}
            //catch (ValidationException ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException });
            //}
            //catch (Exception ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });
            //}

            return null;
        }
    }
}

