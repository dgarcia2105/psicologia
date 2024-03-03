using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Models.Entidades;
using Newtonsoft.Json;
using System.IO;

namespace MM.CAAM.Admin.Web.Controllers
{
    //[Authorize]
    public class UsuarioController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;
        private readonly IFtpService ftpService;
        private readonly string UsuarioFtp, PasswordFtp, UrlServidorFtp;
        private readonly IConfiguration Configuration;

        public UsuarioController(ILogger<HomeController> logger, IUsuarioService usuarioService, IConfiguration configuration, IFtpService ftpService)
        {
            this._logger = logger;
            this.usuarioService = usuarioService;
            this.Configuration = configuration;
            this.UsuarioFtp = Configuration.GetSection("UsuarioFtp").Value;
            this.PasswordFtp = Configuration.GetSection("PasswordFtp").Value;
            this.UrlServidorFtp = Configuration.GetSection("FtpUrl").Value;
            this.ftpService = ftpService;
        }

        public async Task<IActionResult> Index()
        {
            var Usuarios = await usuarioService.ObtenerListaUsuarios();
            var responseCookie = HttpContext.Request.Cookies[".AUTHCAAM"];
            var a = Com.Decryptor(responseCookie);
            var result = JsonConvert.DeserializeObject<UsuarioProfile>(a);
            //ViewBag.Usuario = Response.Cookies["Usuario"];

            return View(Usuarios);
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuarios()
        {
            var Usuarios = await usuarioService.ObtenerListaUsuarios();

            return Usuarios;
        }

        [Authorize(Roles = "ADMINISTRADOR, CEO, JEFE")]
        public async Task<IActionResult> NuevoUsuario(string usuarioId = "")
        {
            UsuarioDTO usuarioDto = new UsuarioDTO();
            if (!string.IsNullOrEmpty(usuarioId))
            {
                int.TryParse(Com.Decryptor(usuarioId), out int id);
                usuarioDto = await usuarioService.ObtenerUsuario(id);
            }

            #region CATALOGOS
            var catalogos = await usuarioService.ObtenerCatalogos();
            ViewBag.Generos = new SelectList(items: catalogos.ListGenero, dataValueField: nameof(Genero.Id), dataTextField: nameof(Genero.Descripcion), usuarioDto.GeneroId);
            ViewBag.ListEstadoCivil = new SelectList(items: catalogos.ListEstadoCivil, dataValueField: nameof(EstadoCivil.Id), dataTextField: nameof(EstadoCivil.Descripcion), usuarioDto.EstadoCivilId);
            ViewBag.ListTipoUsuario = new SelectList(items: catalogos.ListTipoUsuario, dataValueField: nameof(TipoUsuario.Id), dataTextField: nameof(TipoUsuario.Descripcion), usuarioDto.TipoUsuarioId);
            ViewBag.ListGradoEducacion = new SelectList(items: catalogos.ListGradoEducacion, dataValueField: nameof(GradoEducacion.Id), dataTextField: nameof(GradoEducacion.Descripcion), usuarioDto.GradoEducacionId);
            ViewBag.ListEstadoVida = new SelectList(items: catalogos.ListEstadoVida, dataValueField: nameof(EstadoVida.Id), dataTextField: nameof(EstadoVida.Descripcion), usuarioDto.EstadoVidaId);
            ViewBag.Roles = new SelectList(items: catalogos.ListRol, dataValueField: nameof(Rol.Id), dataTextField: nameof(Rol.Descripcion), usuarioDto.RolId);
            #endregion

            return View(usuarioDto);
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDto, int id, IFormFile PerfilNombreArchivo) //, HttpPostedFileBase PerfilNombreArchivo
        {
            try
            {
                #region Upload imagen perfil
                //TODO: detectar tipo de documento y si es imagen hacerla mas chica
                if (PerfilNombreArchivo != null && PerfilNombreArchivo.Length > 0)
                {
                    #region Variables
                    var pathFile = Path.GetTempFileName();
                    var fileName = "/" + Com.RenombrarSiExisteArchivo(PerfilNombreArchivo.FileName);
                    var directory = "/machuca/imagenes_perfil";
                    #endregion
                    #region copytmp
                    using (var stream = System.IO.File.Create(pathFile))
                    {
                        await PerfilNombreArchivo.CopyToAsync(stream);
                    }
                    #endregion
                    var pathServer = "https://"+await ftpService.UploadFile(pathFile, UrlServidorFtp, directory, UsuarioFtp, PasswordFtp, fileName);
                    usuarioCreacionDto.PathImagenPerfil = pathServer;
                }
                #endregion

                #region Validaciones

                if (!string.IsNullOrEmpty(usuarioCreacionDto.Password))
                {
                    if (!usuarioCreacionDto.Password.Equals(usuarioCreacionDto.ConfirmarPassword))
                    {
                        throw new Exception("Las contraseñas no coinciden");
                    }
                }
                #endregion

                #region WebApi
                if (id > 0)
                {
                    await usuarioService.ActualizarUsuario(usuarioCreacionDto, id);
                }
                else
                {
                    await usuarioService.InsertUsuario(usuarioCreacionDto);
                }
                #endregion

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

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> SubirImagenPerfil(IFormFile file, int id) //, HttpPostedFileBase PerfilNombreArchivo
        {
            return null;
        }
    }
}