using MM.CAAM.Gestion.WebApi.DTOs;
using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public ActionResult CrearUsuario(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            string FirstName = usuarioCreacionDTO.Nombre;

            return RedirectToAction("Index");
        }
    }
}