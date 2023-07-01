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

            //README:
            //Enviar E-Mail: https://www.udemy.com/course/aprende-aspnet-core-mvc-haciendo-proyectos-desde-cero/learn/lecture/29473652#overview
            //RESTService   https://www.youtube.com/watch?v=Q12rpPdPcD8
                            //https://jsonplaceholder.typicode.com/
            return RedirectToAction("Index");
        }
    }
}