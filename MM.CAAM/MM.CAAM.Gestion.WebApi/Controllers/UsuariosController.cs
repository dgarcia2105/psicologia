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
using MM.CAAM.Gestion.WebApi.Migrations;
using Microsoft.AspNetCore.DataProtection;
using MM.CAAM.Gestion.Services;

namespace MM.CAAM.Gestion.WebApi.Controllers    
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)  //DTOs y AUTOMAPPER
        {
            var userRepetido = await context.Usuarios.Where(x =>    x.Correo.Equals(usuarioCreacionDTO.Correo)
                                                                                 ||  x.NombrePerfil.Equals(usuarioCreacionDTO.NombrePerfil)).FirstOrDefaultAsync();

            if(userRepetido != null) 
            {
                var valorRepetido = userRepetido.Correo.Equals(usuarioCreacionDTO.Correo) ? $"Ya existe el correo: {usuarioCreacionDTO.Correo}" :
                                                                                            $"Ya existe el usuario: {usuarioCreacionDTO.NombrePerfil}";
                return BadRequest(valorRepetido);
            }

            #region SET VALORES

            usuarioCreacionDTO.Password = Encryptor(usuarioCreacionDTO.Password);
            usuarioCreacionDTO.FechaCreacion = Com.GetUtcNowByZone();

            #endregion

            var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);                              //DTOs y AUTOMAPPER     //Libreria automapper: AutoMapper.Extensions.Microsoft.DependencyInjection

            context.Add(usuario);                                                               //INSERTAR REGISTRO
            await context.SaveChangesAsync();                                                   //INSERTAR REGISTRO
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

