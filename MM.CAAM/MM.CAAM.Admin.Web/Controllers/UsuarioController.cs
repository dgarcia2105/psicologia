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
    [Authorize]
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

        public IActionResult NuevoUsuario()
        {
            List<GeneroRequest> Generos = new List<GeneroRequest>()
            {
                new GeneroRequest() { Id = 1, Genero = "Mujer" },
                new GeneroRequest() { Id = 2, Genero = "Hombre" },
                new GeneroRequest() { Id = 3, Genero = "No binario" },
                new GeneroRequest() { Id = 4, Genero = "Prefiero no decirlo" },
                new GeneroRequest() { Id = 5, Genero = "Otro" }
            };
            var GenerosSelect = new SelectList(
                                        items: Generos,
                                        dataValueField: nameof(GeneroRequest.Id),
                                        dataTextField: nameof(GeneroRequest.Genero));
            ViewBag.Generos = GenerosSelect;

            List<RolDTO> Roles = new List<RolDTO>()
            {
                new RolDTO() { Id = 4, Rol = "Paciente" },
                new RolDTO() { Id = 3, Rol = "Operador" },
                new RolDTO() { Id = 2, Rol = "Jefe" },
                new RolDTO() { Id = 1, Rol = "Administrador" }
            };

            var RolesSelect = new SelectList(
                                        items: Roles,
                                        dataValueField: nameof(RolDTO.Id),
                                        dataTextField: nameof(RolDTO.Rol));


            ViewBag.Roles = RolesSelect;
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