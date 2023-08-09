using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.Objects;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class LogginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService UsuarioService;

        public LogginController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            UsuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> IniciarSesion(UsuarioDTO usuarioDto)
        {
            try
            {
                //// Generar Cookie con los datos de autentificacion
                //var resultDto = await UsuarioService.LoginApi(usuarioDto);

                //UsuarioProfile usuarioLogeado = new UsuarioProfile()
                //{
                //    Usuario = resultDto
                //};

                //// Encrypt the ticket.
                //string encTicket = JsonConvert.SerializeObject(usuarioLogeado);
                //string encriptado = Com.Encryptor(encTicket);
                //var HttpCookie = new HttpCookie(".AUTHCENTRAL", encriptado)
                //{
                //    Expires = DateTime.Now.AddSeconds(FormsAuthentication.Timeout.TotalSeconds),
                //    Secure = true
                //};
                //// Create the cookie.
                //HttpContext.Response.Cookies.Add(HttpCookie);

                //// Exito
                //JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            }
            catch (ValidationException ex)
            {
                //var error = new ExceptionMessage(ex);
                //JResult.Data = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            }
            catch (Exception ex)
            {
                //var error = new ExceptionMessage(ex);
                //return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            }

            //return JResult;

            return null;
        }
    }
}