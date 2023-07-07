using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Objects;
using MM.CAAM.Admin.Services.Servicios.Test;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using MM.CAAM.Admin.Services.Exceptions;

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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> IniciarSesion(UsuarioDto usuarioDTO)
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

            try
            {
                // Generar Cookie con los datos de autentificacion
                var resultDto = await usuarioService.LoginApi(usuarioDTO);

                UsuarioProfile usuarioDTOLogeado = new UsuarioProfile()
                {
                    UsuarioDto = resultDto
                };

                // Encrypt the ticket.
                string encTicket = JsonConvert.SerializeObject(usuarioDTOLogeado);
                string encriptado = Com.Encryptor(encTicket);
                var HttpCookie = new HttpCookie(".AUTHCENTRAL", encriptado)
                {
                    Expires = DateTime.Now.AddSeconds(FormsAuthentication.Timeout.TotalSeconds),
                    Secure = true
                };
                // Create the cookie.
                HttpContext.Response.Cookies.Add(HttpCookie);

                // Exito
                JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
                JResult.Data = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            }

            return null;
        }
    }
}