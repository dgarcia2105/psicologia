using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.Models.Entidades;
using Newtonsoft.Json;


namespace MM.CAAM.Admin.Web.Controllers
{
    public class LogginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService UsuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogginController(ILogger<HomeController> logger, IUsuarioService usuarioService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            UsuarioService = usuarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            UsuarioProfile usuarioLogeado = new UsuarioProfile()
            {
                Usuario = new UsuarioDTO() { Id = 1 }
            };



            // Encrypt the ticket.
            string encTicket = JsonConvert.SerializeObject(usuarioLogeado);
            string encriptado = Com.Encryptor(encTicket);
            
            //var HttpCookie2 = new HttpCookie(".AUTHCENTRAL", encriptado)
            //{
            //    Expires = DateTime.Now.AddSeconds(86400),
            //    Secure = true
            //};
            //// Create the cookie.
            //HttpContext.Response.Cookies.Add(HttpCookie);
            //------------------------------------
            
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(".AUTHCENTRAL", encriptado, options);

            Response.Cookies.Append("2", "1");

            var cookie1 = _httpContextAccessor.HttpContext.Request.Cookies["1"];
            var cookie2 = _httpContextAccessor.HttpContext.Request.Cookies["2"];
            var cookie3 = Com.Decryptor(_httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"]);

            var authCookie = _httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"];
            var cookieDesencriptada = Com.Decryptor(authCookie);
            var usuarioCokie = JsonConvert.DeserializeObject<UsuarioProfile>(cookieDesencriptada);

            //CustomIdentity userIdentity = new CustomIdentity(usuarioCokie.Usuario.Id.ToString());

            //UsuarioPrincipal userPrincipal = new UsuarioPrincipal(userIdentity);
            //HttpContext.Current.User = userPrincipal;

            //userIdentity.UsuarioProfile = usuarioCokie;
            //userIdentity.DisplayName = $"{usuarioCokie.Usuario?.Nombres} {usuarioCokie.Usuario?.Apellidos}";
            //userIdentity.Role = (Roles)usuarioCokie.Usuario?.RolId;

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