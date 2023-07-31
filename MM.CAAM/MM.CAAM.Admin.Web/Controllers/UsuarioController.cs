using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using System.Diagnostics;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UsuarioController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarUsuario()
        {
            List<GeneroRequest> Generos = new List<GeneroRequest>()
            {
                new GeneroRequest() { Id = 1, Genero = "M" },
                new GeneroRequest() { Id = 2, Genero = "F" }
            };
            var GenerosSelect = new SelectList(
                                        items: Generos,
                                        dataValueField: nameof(GeneroRequest.Genero),
                                        dataTextField: nameof(GeneroRequest.Genero));
            ViewBag.Generos = GenerosSelect;

            List<RolDTO> Roles = new List<RolDTO>()
            {
                new RolDTO() { Id = 1, Rol = "1" },
                new RolDTO() { Id = 2, Rol = "2" }
            };

            var RolesSelect = new SelectList(
                                        items: Roles,
                                        dataValueField: nameof(RolDTO.Rol),
                                        dataTextField: nameof(RolDTO.Rol));


            ViewBag.Roles = RolesSelect;
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDto) //, HttpPostedFileBase PerfilNombreArchivo
        {
            return null;
        }
    }
}