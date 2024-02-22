using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MM.CAAM.Gestion.DTO.DTOs;
using Microsoft.AspNetCore.DataProtection;
using MM.CAAM.Gestion.Services;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.Services.Exceptions;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Models.Entidades;
using Microsoft.AspNetCore.Authorization;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.DTOs.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MM.CAAM.Gestion.Models.Controllers    
{
    [ApiController]                                                             //si algo sale mal retorna un bad request
    [Route("api/usuarios")]
    //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IDataProtector dataProtector;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public UsuariosController(UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            ApplicationDbContext context, 
            IMapper mapper,
            IDataProtectionProvider dataProtectionProvider,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.context = context;
            this.mapper = mapper;
            this.signInManager = signInManager;
            dataProtector = dataProtectionProvider.CreateProtector(Com.KeyEncript);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            try
            {
                var usuarios = await context.Usuarios
                    .Include(x => x.Rol)
                    .Include(x => x.GradoEducacion)
                    .Include(x => x.EstadoVida)
                    .Include(x => x.TipoUsuario)
                    .Include(x => x.EstadoCivil)
                    .Include(x => x.Genero)
                    .Where(x => x.Activo == true)
                    .OrderByDescending(u => u.Id).ToListAsync();

                var data = mapper.Map<List<UsuarioDTO>>(usuarios);

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

        [HttpGet("{id:int}", Name = "ObtenerUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            try
            {

                var usuario = await context.Usuarios
                    .Where(x => x.Activo == true)
                    .Include(usuarioDB => usuarioDB.TipoUsuario) 
                    .FirstOrDefaultAsync(usuarioBD => usuarioBD.Id == id); //usuarioBD.Negocios || Consultas

                if (usuario == null)
                {
                    throw new ArgumentNullException(nameof(usuario));
                }

                var data = mapper.Map<UsuarioDTO>(usuario);

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

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get([FromRoute] string nombre)
        {
            var usuarios = await context.Usuarios
                .Where(UsuarioBd => UsuarioBd.Nombre.Contains(nombre) && UsuarioBd.Activo == true)
                .ToListAsync();

            return mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            try
            {
                if (!string.IsNullOrEmpty(usuarioCreacionDTO.NombrePerfil) || !string.IsNullOrEmpty(usuarioCreacionDTO.Correo))
                {
                    var userRepetido = await context.Usuarios.Where(x => (!string.IsNullOrEmpty(usuarioCreacionDTO.Correo) && x.Correo.Equals(usuarioCreacionDTO.Correo))
                                                                                     || (!string.IsNullOrEmpty(usuarioCreacionDTO.NombrePerfil) && x.NombrePerfil.Equals(usuarioCreacionDTO.NombrePerfil))).FirstOrDefaultAsync();

                    if (userRepetido != null && (!string.IsNullOrEmpty(usuarioCreacionDTO.NombrePerfil) || !string.IsNullOrEmpty(usuarioCreacionDTO.Correo)))
                    {
                        var valorRepetido = !string.IsNullOrEmpty(userRepetido.Correo) && userRepetido.Correo.ToUpper().Equals(usuarioCreacionDTO.Correo.ToUpper()) ? $"Ya existe el correo: {usuarioCreacionDTO.Correo}" :
                                                                                                    $"Ya existe el usuario: {usuarioCreacionDTO.NombrePerfil}";

                        throw new ArgumentException(valorRepetido);
                    }
                }

                #region SET VALORES
                if (!string.IsNullOrEmpty(usuarioCreacionDTO.Password))
                {
                    //usuarioCreacionDTO.Password = Encryptor(usuarioCreacionDTO.Password);
                    usuarioCreacionDTO.Password = usuarioCreacionDTO.Password;
                }
                usuarioCreacionDTO.FechaCreacion = Com.GetUtcNowByZone();

                #endregion

                #region NOMBRE MAYUSCULAS
                usuarioCreacionDTO.Nombre = usuarioCreacionDTO.Nombre.ToUpper();
                usuarioCreacionDTO.ApellidoPaterno = usuarioCreacionDTO.ApellidoPaterno.ToUpper();
                usuarioCreacionDTO.ApellidoMaterno = usuarioCreacionDTO.ApellidoMaterno.ToUpper();
                #endregion

                var usuario = mapper.Map<Usuario>(usuarioCreacionDTO);

                context.Add(usuario);
                await context.SaveChangesAsync();

                //var usuarioDTO = mapper.Map<UsuarioDTO>(usuario);

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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            if (usuario.Id != id)
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

        [HttpDelete("{id:int}")]
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                #region (1) UsuarioService.Login
                if (userLoginRequest == null) throw new ArgumentNullException(nameof(userLoginRequest));
                if (string.IsNullOrWhiteSpace(userLoginRequest.Email)) throw new ArgumentNullException(nameof(userLoginRequest.Email));
                if (string.IsNullOrWhiteSpace(userLoginRequest.Password)) throw new ArgumentNullException(nameof(userLoginRequest.Password));

                var usuario = await context.Usuarios
                                    .Where(x => x.Activo == true)
                                    .FirstOrDefaultAsync(usuarioBD => usuarioBD.Correo.ToUpper() == userLoginRequest.Email.ToUpper());

                if (usuario == null)
                {
                    throw new ValidationException("El usuario no existe en nuestra app");
                }

                if (string.IsNullOrWhiteSpace(usuario.Password))
                {
                    throw new ValidationException("Configure su contraseña");
                }

                //var contrasenaDesencriptada = Decryptor(usuario.Password);
                var contrasenaDesencriptada = usuario.Password;
                if (!contrasenaDesencriptada.Equals(userLoginRequest.Password))
                {
                    throw new ValidationException("Error de contraseña");
                }
                #endregion  

                var data = await ConstruirToken(usuario);
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

        private async Task<AuthResponse> ConstruirToken(Usuario usuario)
        {
            #region GenerateToken

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim("Correo", !string.IsNullOrEmpty(usuario.Correo) ? usuario.Correo : ""),
                    new Claim("NombrePerfil", !string.IsNullOrEmpty(usuario.NombrePerfil) ? usuario.NombrePerfil : ""),
                    new Claim("Nombre", usuario.Nombre.ToString()),
                    new Claim("ApellidoPaterno", usuario.ApellidoPaterno.ToString()),
                    new Claim("ApellidoMaterno", usuario.ApellidoMaterno.ToString())
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1)
                //,SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var newJwtToken = tokenString;

            #endregion
             
            var authResponse = new AuthResponse()
            {
                UsuarioId = usuario.Id,                  //TODO:
                BearerToken = newJwtToken
                //,RefreshToken = newRefreshToken,
                //FCMToken = entity.fcm_token
            };

            return authResponse;
        }

        [HttpGet("obtener_catalogos")]
        public async Task<ActionResult<CatalogoDTO>> ObtenerCatalogos()
        {
            try
            {
                var listRoles =          await context.Rol
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();
                var listEstadoVida =     await context.EstadoVida
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();
                var listGradoEducacion = await context.GradoEducacion
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();
                var listTipoUsuario =    await context.TipoUsuario
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();
                var listGenero =         await context.Genero
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();
                var listEstadoCivil =    await context.EstadoCivil
                                                .Where(x => x.Activo == true).OrderBy(u => u.Orden).ToListAsync();

                CatalogoDTO catalogoDto = new CatalogoDTO();
                catalogoDto.ListRol = listRoles;
                catalogoDto.ListEstadoVida = listEstadoVida;
                catalogoDto.ListGradoEducacion = listGradoEducacion;
                catalogoDto.ListTipoUsuario = listTipoUsuario;
                catalogoDto.ListGenero = listGenero;
                catalogoDto.ListEstadoCivil = listEstadoCivil;

                return Ok(new Result { Code = StatusCodes.Status200OK, Data = catalogoDto });
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

