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
using MM.CAAM.Gestion.DTO.DTOs.Udemy;
using MM.CAAM.Gestion.Models.Migrations;
using Microsoft.AspNetCore.DataProtection;
using MM.CAAM.Gestion.Services;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;

namespace MM.CAAM.Gestion.Models.Controllers    
{
    [ApiController]                                                             //si algo sale mal retorna un bad request
    [Route("api/usuarios")]
    //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IDataProtector dataProtector;

        public UsuariosController(ApplicationDbContext context, 
            IMapper mapper,
            IDataProtectionProvider dataProtectionProvider)
        {
            this.context = context;
            this.mapper = mapper;
            dataProtector = dataProtectionProvider.CreateProtector(Com.KeyEncript);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            var usuarios = await context.Usuarios.Include(x => x.Negocios).ToListAsync();

            return mapper.Map<List<UsuarioDTO>>(usuarios);                                  //LEYENDO REGISTROS con EF Core
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            //var usuario = await context.Usuarios.FirstOrDefaultAsync(usuarioBD => usuarioBD.Id == id);        //BAK
            var usuario = await context.Usuarios
                .Include(usuarioBD => usuarioBD.Negocios).FirstOrDefaultAsync(usuarioBD => usuarioBD.Id == id); //usuarioBD.Negocios || Consultas

            if (usuario == null)
            {
                return NotFound();
            }

            return mapper.Map<UsuarioDTO>(usuario);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get([FromRoute] string nombre)
        {
            var usuarios = await context.Usuarios.Where(UsuarioBd => UsuarioBd.Nombre.Contains(nombre)).ToListAsync();

            return mapper.Map<List<UsuarioDTO>>(usuarios);
        }


        //[HttpPost("lista")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)  //DTOs y AUTOMAPPER
        {
            try
            {

                var userRepetido = await context.Usuarios.Where(x => x.Nombre.ToUpper().Equals(usuarioCreacionDTO.Nombre.ToUpper())
                                                                                 && x.ApellidoPaterno.ToUpper().Equals(usuarioCreacionDTO.ApellidoPaterno.ToUpper())
                                                                                 && x.ApellidoMaterno.ToUpper().Equals(usuarioCreacionDTO.ApellidoMaterno.ToUpper())).FirstOrDefaultAsync();

                if (userRepetido != null)
                {
                    //var valorRepetido = userRepetido.Correo.Equals(usuarioCreacionDTO.Correo) ? $"Ya existe el correo: {usuarioCreacionDTO.Correo}" :
                    //                                                                            $"Ya existe el usuario: {usuarioCreacionDTO.NombrePerfil}";

                    var valorRepetido = "Ya existe";

                    throw new ArgumentException(valorRepetido);
                }

                #region SET VALORES
                if (!string.IsNullOrEmpty(usuarioCreacionDTO.Password))
                {
                    usuarioCreacionDTO.Password = Encryptor(usuarioCreacionDTO.Password);
                }
                usuarioCreacionDTO.FechaCreacion = Com.GetUtcNowByZone();

                #endregion

                var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);                              //DTOs y AUTOMAPPER     //Libreria automapper: AutoMapper.Extensions.Microsoft.DependencyInjection

                context.Add(usuario);                                                               //INSERTAR REGISTRO
                await context.SaveChangesAsync();                                                   //INSERTAR REGISTRO
                //return Ok();

            
                //var data = await DiligenciaService.ObtenerLista(obtenerDiligenciaRequest);
                //data = data.Where(x => x.AutorizaProgramacion).ToList();
                //return Ok(new Result { Code = StatusCodes.Status200OK, Data = data });
                return Ok(new Result { Code = StatusCodes.Status200OK});
                //return Ok();
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

        [HttpGet("desencriptar")]
        public string Decryptor(string stringToDecrypt)
        {
            //var textoCifrado = dataProtector.Protect(textoPlano);
            var textoDesencriptado = dataProtector.Unprotect(stringToDecrypt);

            return textoDesencriptado;
        }

        [HttpGet("encriptar")]
        public string Encryptor(string stringToEncrypt)
        {
            var textoCifrado = dataProtector.Protect(stringToEncrypt);

            return textoCifrado;
        }
    }
}

