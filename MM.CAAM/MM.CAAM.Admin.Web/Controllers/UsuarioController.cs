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
            List<GeneroRequest> listGenero = new List<GeneroRequest>()
            {
                new GeneroRequest() { Id = 1, Genero = "Mujer" },
                new GeneroRequest() { Id = 2, Genero = "Hombre" },
                new GeneroRequest() { Id = 3, Genero = "No binario" },
                new GeneroRequest() { Id = 4, Genero = "Prefiero no decirlo" },
                new GeneroRequest() { Id = 5, Genero = "Otro" }
            };
            var GenerosSelect = new SelectList(
                                        items: listGenero,
                                        dataValueField: nameof(GeneroRequest.Id),
                                        dataTextField: nameof(GeneroRequest.Genero));
            ViewBag.Generos = GenerosSelect;

            List<EstadoCivilRequest> listEstadoCivil = new List<EstadoCivilRequest>()
            {
                new EstadoCivilRequest() { Id = 1, EstadoCivil = "Soltero/a" },
                new EstadoCivilRequest() { Id = 2, EstadoCivil = "Casado/a" },
                new EstadoCivilRequest() { Id = 3, EstadoCivil = "Unión libre o unión de hecho" },
                new EstadoCivilRequest() { Id = 4, EstadoCivil = "Separado/a" },
                new EstadoCivilRequest() { Id = 5, EstadoCivil = "Divorciado/a" },
                new EstadoCivilRequest() { Id = 5, EstadoCivil = "Viodo/a" }
            };
            ViewBag.ListEstadoCivil = new SelectList(
                                        items: listEstadoCivil,
                                        dataValueField: nameof(EstadoCivilRequest.Id),
                                        dataTextField: nameof(EstadoCivilRequest.EstadoCivil));
             
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
             
            List<RolDTO> listRoles = new List<RolDTO>()
            {
                new RolDTO() { Id = 4, Rol = "Paciente" },
                new RolDTO() { Id = 3, Rol = "Operador" },
                new RolDTO() { Id = 2, Rol = "Jefe" },
                new RolDTO() { Id = 1, Rol = "Administrador" }
            };

            ViewBag.Roles = new SelectList(
                                        items: listRoles,
                                        dataValueField: nameof(RolDTO.Id),
                                        dataTextField: nameof(RolDTO.Rol));
 
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