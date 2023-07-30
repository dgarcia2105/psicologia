using MM.CAAM.Admin.Services.Servicios.Test;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Gestion.DTO.DTOs;

namespace MM.CAAM.Web.Controllers
{
    public class LogginController : BaseController
    {
        private readonly IUsuarioService usuarioService;

        //private readonly ITestService TestService;

        public LogginController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
            //TestService = testService;
        }

        public IActionResult Index()
        {
            //return View();
            return null;
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> IniciarSesion(UsuarioDTO usuarioDTO)
        {
            //Post post = new Post()
            //{
            //    userId = 50,
            //    body = "Hola como estas",
            //    title = "Titulo de saludo"
            //};
            //var postResponse = await TestService.PostTest(post);
            //var postResponse2 = await TestService.PutTest(post);
            //var postResponse3 = await TestService.DeleteTest(post);


            //string FirstName = usuarioCreacionDTO.Nombre;

            //return RedirectToAction("Index");

            ////TODO:
            //try
            //{
            //    // Generar Cookie con los datos de autentificacion
            //    var resultDto = await usuarioService.LoginApi(usuarioDTO);

            //    UsuarioProfile usuarioDTOLogeado = new UsuarioProfile()
            //    {
            //        UsuarioDto = resultDto
            //    };

            //    // Encrypt the ticket.
            //    string encTicket = JsonConvert.SerializeObject(usuarioDTOLogeado);
            //    string encriptado = Com.Encryptor(encTicket);
            //    // TODO ASP.NET membership should be replaced with ASP.NET Core identity. For more details see https://docs.microsoft.com/aspnet/core/migration/proper-to-2x/membership-to-core-identity.
            //    var HttpCookie = new HttpCookie(".AUTHCENTRAL", encriptado)
            //    {
            //        Expires = DateTime.Now.AddSeconds(FormsAuthentication.Timeout.TotalSeconds),
            //        Secure = true
            //    };
            //    // Create the cookie.
            //    HttpContext.Response.Cookies.Add(HttpCookie);

            //    // Exito
            //    JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            //}
            //catch (ValidationException ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    JResult.Data = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            //}
            //catch (Exception ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            //}

            return null;
        }
    }
}