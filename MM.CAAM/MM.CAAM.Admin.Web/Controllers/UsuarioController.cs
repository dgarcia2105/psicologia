using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.Objects;

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

        public IActionResult NuevoUsuario()
        {
            List<TipoRequest> listGenero = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Mujer" },
                new TipoRequest() { Id = 2, Descripcion = "Hombre" },
                new TipoRequest() { Id = 3, Descripcion = "No binario" },
                new TipoRequest() { Id = 4, Descripcion = "Prefiero no decirlo" },
                new TipoRequest() { Id = 5, Descripcion = "Otro" }
            };
            var GenerosSelect = new SelectList(
                                        items: listGenero,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
            ViewBag.Generos = GenerosSelect;

            List<TipoRequest> listEstadoCivil = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Soltero/a" },
                new TipoRequest() { Id = 2, Descripcion = "Casado/a" },
                new TipoRequest() { Id = 3, Descripcion = "Unión libre o unión de hecho" },
                new TipoRequest() { Id = 4, Descripcion = "Separado/a" },
                new TipoRequest() { Id = 5, Descripcion = "Divorciado/a" },
                new TipoRequest() { Id = 5, Descripcion = "Viudo/a" }
            };
            ViewBag.ListEstadoCivil = new SelectList(
                                        items: listEstadoCivil,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
             
            List<TipoRequest> listTipoUsuario = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Privado" },
                new TipoRequest() { Id = 2, Descripcion = "Empresa" }
            };
            ViewBag.ListTipoUsuario = new SelectList(
                                        items: listTipoUsuario,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
            
            List<TipoRequest> listGradoEducacion = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Doctorado" },
                new TipoRequest() { Id = 2, Descripcion = "Maestria" },
                new TipoRequest() { Id = 3, Descripcion = "Licenciatura" },
                new TipoRequest() { Id = 4, Descripcion = "Bachillerato" },
                new TipoRequest() { Id = 5, Descripcion = "Secundaria" },
                new TipoRequest() { Id = 6, Descripcion = "Primaria" }
            };
            ViewBag.ListGradoEducacion = new SelectList(
                                        items: listGradoEducacion,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
             
            List<TipoRequest> listEstadoVida = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Activo" },
                new TipoRequest() { Id = 2, Descripcion = "Inactivo" }
            };
            ViewBag.ListEstadoVida = new SelectList(
                                        items: listEstadoVida,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
             
            List<TipoRequest> listRoles = new List<TipoRequest>()
            {
                new TipoRequest() { Id = 1, Descripcion = "Administrador" },
                new TipoRequest() { Id = 2, Descripcion = "Jefe" },
                new TipoRequest() { Id = 3, Descripcion = "Operador" },
                new TipoRequest() { Id = 4, Descripcion = "Paciente" }
            };

            ViewBag.Roles = new SelectList(
                                        items: listRoles,
                                        dataValueField: nameof(TipoRequest.Id),
                                        dataTextField: nameof(TipoRequest.Descripcion));
 
            return View();
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