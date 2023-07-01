using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Servicios.Test;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ITestService TestService;

        public UsuarioController(ITestService testService)
        {
            TestService = testService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            Post post = new Post()
            {
                userId = 50,
                body = "Hola como estas",
                title = "Titulo de saludo"
            };
            var Diligencias = await TestService.PostTest(post);


            string FirstName = usuarioCreacionDTO.Nombre;

            //README:
            //Enviar E-Mail: https://www.udemy.com/course/aprende-aspnet-core-mvc-haciendo-proyectos-desde-cero/learn/lecture/29473652#overview
            //RESTService   https://www.youtube.com/watch?v=Q12rpPdPcD8
                            //https://jsonplaceholder.typicode.com/
            return RedirectToAction("Index");
        }
    }
}