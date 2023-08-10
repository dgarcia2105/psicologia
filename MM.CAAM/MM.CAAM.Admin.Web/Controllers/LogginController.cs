using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Gestion.DTO.DTOs;
using Newtonsoft.Json; 

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
                // Generar Cookie con los datos de autentificacion
                var resultDto = await UsuarioService.LoginApi(usuarioDto);

                //UsuarioProfile usuarioLogeado = new UsuarioProfile()
                //{
                //    Usuario = resultDto
                //};

                //// Encrypt the ticket.
                //string encTicket = JsonConvert.SerializeObject(usuarioLogeado);
                //string encriptado = Com.Encryptor(encTicket);

                // Response.Cookies.Append(".AUTHCENTRAL", ".AUTHCENTRAL");
                //var authCookie = Request.Cookies[".AUTHCENTRAL"];

                //var cookieOptions = new CookieOptions();
                //cookieOptions.Expires = DateTime.Now.AddDays(1);
                //cookieOptions.Path = "/";
                //Response.Cookies.Append("SomeCookie", "SomeValue", cookieOptions);

                //var cookie = Request.Cookies["SomeCookie"];
                ////var cookie2 = Request.Cookies.Get("SomeCookie");

                //HttpContext.Response.Cookies.Append(".user_id", "1"); 
                //var userId = HttpContext.Request.Cookies[".user_id"];
                //var bak = HttpContext.Request.Cookies[".AspNetCore.Antiforgery.AwSt3fPBBK8"];
                

                //HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString());
                //var a = HttpContext.Request.Cookies["first_request"];
                //DateTime firstRequest = DateTime.Parse(a);
                //var dateString = firstRequest.ToString();

                //var cookieOpt = new CookieOptions()
                //{
                //    Path = "/",
                //    Expires = DateTimeOffset.UtcNow.AddDays(1),
                //    IsEssential = true,
                //    HttpOnly = false,
                //    Secure = false,
                //};
                //HttpContext.Response.Cookies.Append("MyCookieId", "SomeCookieID", cookieOpt);
                //var b = HttpContext.Request.Cookies["MyCookieId"];

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