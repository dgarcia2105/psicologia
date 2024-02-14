using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Catalogos;
using MM.CAAM.Gestion.DTO.DTOs.Udemy;
using MM.CAAM.Gestion.Models.Entidades;
using MM.CAAM.Gestion.Models.Entidades.Catalogos;
using MM.CAAM.Gestion.Models.Migrations;
using static Azure.Core.HttpHeader;
//using GrupoAlimenticio = MM.CAAM.Gestion.Models.Entidades.GrupoAlimenticio;
using GrupoAlimenticio = MM.CAAM.Gestion.Models.Entidades.Catalogos.GrupoAlimenticio;

namespace MM.CAAM.Gestion.Models.Controllers.Catalogos
{
    [ApiController]
    [Route("api/tipos")]             
    public class TiposController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TiposController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ConsultaDTO>>> Get(int usuarioId)
        //{
        //    var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);

        //    if (!existeUsuario)
        //    {
        //        return NotFound();
        //    }

        //    var consultas = await context.Consultas
        //        .Where(consultasDB => consultasDB.UsuarioId == usuarioId).ToListAsync();
        //    return mapper.Map<List<ConsultaDTO>>(consultas);
        //}

        [HttpPost]
        public async Task<ActionResult> Post(int usuarioId, ConsultaCreacionDTO consultaCreacionDTO)
        {
            //var existeUsuario = await context.Usuarios.AnyAsync(usuarioDB => usuarioDB.Id == usuarioId);

            //if (!existeUsuario)
            //{
            //    return NotFound();
            //}

            //var consulta = mapper.Map<Consulta>(consultaCreacionDTO);
            //consulta.UsuarioId = usuarioId;
            //context.Add(consulta);
            //await context.SaveChangesAsync();
            //return Ok();
            return null;
        }

        #region CATALOGOS
        [HttpPost("grupos_alimenticios")]
        public async Task<ActionResult> GuardarGruposAlimenticios([FromBody] List<CatalogoCreacionDTO> listaCatalogoCreacionDTO)
        {
            var list = (await context.GrupoAlimenticios.ToListAsync()).Where(x => listaCatalogoCreacionDTO.Any(y => y.Descripcion.Equals(x.Descripcion, StringComparison.InvariantCultureIgnoreCase))).ToList();   //TODO: es TOListAsync a comparacion de AnyAsync Ver que tan pesado 

            if (list.Count > 0)
            {
                return BadRequest($"Ya existe la descripcion {String.Join(", ", list.Select(x => x.Descripcion).ToArray())}"); ///*{String.Join(", ", list.Select(x => x.Descripcion).ToArray())}*/
            }

            var entidad = mapper.Map<List<GrupoAlimenticio>>(listaCatalogoCreacionDTO);                              

            context.AddRange(entidad);                                                               
            await context.SaveChangesAsync();                                                   
            return Ok();
        }

        [HttpPost("proveedores")]
        public async Task<ActionResult> GuardarProveedores([FromBody] List<CatalogoCreacionDTO> listaCatalogoCreacionDTO)
        {
            var list = (await context.Proveedores.ToListAsync()).Where(x => listaCatalogoCreacionDTO.Any(y => y.Descripcion.Equals(x.Descripcion, StringComparison.InvariantCultureIgnoreCase))).ToList();   //TODO: es TOListAsync a comparacion de AnyAsync Ver que tan pesado 

            if (list.Count > 0)
            {
                return BadRequest($"Ya existe la descripcion {String.Join(", ", list.Select(x => x.Descripcion).ToArray())}"); ///*{String.Join(", ", list.Select(x => x.Descripcion).ToArray())}*/
            }

            var entidad = mapper.Map<List<Proveedor>>(listaCatalogoCreacionDTO);

            context.AddRange(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("secciones_supermercado")]
        public async Task<ActionResult> GuardarSeccionesSupermercado([FromBody] List<CatalogoCreacionDTO> listaCatalogoCreacionDTO)
        {
            var list = (await context.SeccionesSupermercado.ToListAsync()).Where(x => listaCatalogoCreacionDTO.Any(y => y.Descripcion.Equals(x.Descripcion, StringComparison.InvariantCultureIgnoreCase))).ToList();   //TODO: es TOListAsync a comparacion de AnyAsync Ver que tan pesado 

            if (list.Count > 0)
            {
                return BadRequest($"Ya existe la descripcion {String.Join(", ", list.Select(x => x.Descripcion).ToArray())}"); ///*{String.Join(", ", list.Select(x => x.Descripcion).ToArray())}*/
            }

            var entidad = mapper.Map<List<SeccionSupermercado>>(listaCatalogoCreacionDTO);

            context.AddRange(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("tipo_grupos")]
        public async Task<ActionResult> GuardarTipoGrupos([FromBody] List<CatalogoCreacionDTO> listaCatalogoCreacionDTO)
        {
            var list = (await context.TiposGrupo.ToListAsync()).Where(x => listaCatalogoCreacionDTO.Any(y => y.Descripcion.Equals(x.Descripcion, StringComparison.InvariantCultureIgnoreCase))).ToList();   //TODO: es TOListAsync a comparacion de AnyAsync Ver que tan pesado 

            if (list.Count > 0)
            {
                return BadRequest($"Ya existe la descripcion {String.Join(", ", list.Select(x => x.Descripcion).ToArray())}"); ///*{String.Join(", ", list.Select(x => x.Descripcion).ToArray())}*/
            }

            var entidad = mapper.Map<List<TipoGrupo>>(listaCatalogoCreacionDTO);

            context.AddRange(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("unidad_medidas")]
        public async Task<ActionResult> GuardarUnidadMedidas([FromBody] List<CatalogoCreacionDTO> listaCatalogoCreacionDTO)
        {
            //var list = (await context.UnidadesMedida.ToListAsync()).Where(x => listaCatalogoCreacionDTO.Any(y => y.Descripcion.Equals(x.Descripcion, StringComparison.InvariantCultureIgnoreCase))).ToList();   //TODO: es TOListAsync a comparacion de AnyAsync Ver que tan pesado 

            //if (list.Count > 0)
            //{
            //    return BadRequest($"Ya existe la descripcion {String.Join(", ", list.Select(x => x.Descripcion).ToArray())}"); ///*{String.Join(", ", list.Select(x => x.Descripcion).ToArray())}*/
            //}

            //var entidad = mapper.Map<List<UnidadMedida>>(listaCatalogoCreacionDTO);

            //context.AddRange(entidad);
            //await context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}
