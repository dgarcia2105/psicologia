using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Gestion.Models.Entidades;

namespace MM.CAAM.Admin.Web.Controllers
{
    //[Authorize]
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var Usuarios = await usuarioService.ObtenerListaUsuarios();

            return View(Usuarios);
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuarios()
        {
            var Usuarios = await usuarioService.ObtenerListaUsuarios();

            return Usuarios;
        }

        public async Task<IActionResult> NuevoUsuario(string usuarioId)
        {
            if (string.IsNullOrEmpty(usuarioId))
                throw new ValidationException("Id vacío.");

            int.TryParse(Com.Decryptor(usuarioId), out int id);
            var usuarioDto = await usuarioService.ObtenerUsuario(id); //, UsuarioProfile.Usuario.BearerToken

            #region CATALOGOS
            var catalogos = await usuarioService.ObtenerCatalogos();
            ViewBag.Generos = new SelectList( items: catalogos.ListGenero, dataValueField: nameof(Genero.Id), dataTextField: nameof(Genero.Descripcion), usuarioDto.GeneroId);
            ViewBag.ListEstadoCivil = new SelectList( items: catalogos.ListEstadoCivil, dataValueField: nameof(EstadoCivil.Id), dataTextField: nameof(EstadoCivil.Descripcion), usuarioDto.EstadoCivilId);
            ViewBag.ListTipoUsuario = new SelectList( items: catalogos.ListTipoUsuario, dataValueField: nameof(TipoUsuario.Id), dataTextField: nameof(TipoUsuario.Descripcion), usuarioDto.TipoUsuarioId);
            ViewBag.ListGradoEducacion = new SelectList( items: catalogos.ListGradoEducacion, dataValueField: nameof(GradoEducacion.Id), dataTextField: nameof(GradoEducacion.Descripcion), usuarioDto.GradoEducacionId);
            ViewBag.ListEstadoVida = new SelectList( items: catalogos.ListEstadoVida, dataValueField: nameof(EstadoVida.Id), dataTextField: nameof(EstadoVida.Descripcion), usuarioDto.EstadoVidaId);
            ViewBag.Roles = new SelectList( items: catalogos.ListRol, dataValueField: nameof(Rol.Id), dataTextField: nameof(Rol.Descripcion), usuarioDto.RolId);
            #endregion

            return View(usuarioDto);
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDto) //, HttpPostedFileBase PerfilNombreArchivo
        {
            try
            {
                if(!string.IsNullOrEmpty(usuarioCreacionDto.Password))
                {
                    if (!usuarioCreacionDto.Password.Equals(usuarioCreacionDto.ConfirmarPassword))
                    {
                        throw new Exception("Las contraseñas no coinciden");
                    }
                }

                //if (PerfilNombreArchivo != null && PerfilNombreArchivo.ContentLength > 0)
                //{
                //    var fullPath = Path.Combine(usuarioDto.PathFotosActuarios, PerfilNombreArchivo.FileName);
                //    var fileName = Com.RenombrarSiExisteArchivo(fullPath);
                //    PerfilNombreArchivo.SaveAs(Path.Combine(usuarioDto.PathFotosActuarios, fileName));

                //    usuarioDto.PerfilNombreArchivo = fileName;
                //}
                //else
                //    usuarioDto.PerfilNombreArchivo = null;

                await usuarioService.InsertUsuario(usuarioCreacionDto);
                return Ok(new Result { Code = StatusCodes.Status200OK});
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