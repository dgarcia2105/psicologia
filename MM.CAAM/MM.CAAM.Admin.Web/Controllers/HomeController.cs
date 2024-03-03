using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.Objects;
using MM.CAAM.Admin.Web.Controllers;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.StaticFiles;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class HomeController : BaseController
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;
        private readonly IConfiguration IConfiguration;
        private readonly IFtpService IFtpService;
        private readonly string UsuarioFtp, PasswordFtp, UrlServidorFtp;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService, IConfiguration iConfiguration, IFtpService iFtpService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
            IConfiguration = iConfiguration;
            IFtpService = iFtpService;
            UsuarioFtp = IConfiguration.GetSection("UsuarioFtp").Value;
            PasswordFtp = IConfiguration.GetSection("PasswordFtp").Value;
            UrlServidorFtp = IConfiguration.GetSection("FtpUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            #region Variables
            var pathFile = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot", @"images", @"user_default.png");
            var fileName = "/"+Path.GetFileName(pathFile);
            var directory = "/machuca/imagenes_perfil"; 
            #endregion

            var uploadSuccess = await IFtpService.UploadFile(pathFile, UrlServidorFtp, directory, UsuarioFtp, PasswordFtp);

            #region Meta
            ViewBag.Title = "Caam: Centro psicológico de aprendizaje profesional";
            ViewBag.MetaDescripcion = "Únete hoy a Caam, el centro psicológico profesional de educación en línea y presencial. Prepárate con las habilidades más nuevas y demandadas a un menor precio de lo que gastarías regularmente.";
            ViewBag.MetaKeywords = "psicología, clinica, menor precio, tecnologías, servicios, consulta, online, presencial, psicoterapia, familiar, pareja, infantil, adolescentes, terapia, adultos, asesoramiento, educación, profesional, capacitación, docente, evaluación, duelo, orientacion vocacional, orientación, pruebas, anciedad, ansiedad, rehabilitación, terapia, breve, cognitivo conductual, pareja, test machover, consulta subsecuente, en línea, presencial";
            ViewBag.MetaAuthor = "caam, dgarcia2105, didade";
            #endregion

            return View();
        }

        public IActionResult PoliticaPrivacidad()
        {
            #region Meta
            ViewBag.Title = "Caam: Centro psicológico de aprendizaje profesional";
            ViewBag.MetaDescripcion = "Únete hoy a Caam, el centro psicológico profesional de educación en línea y presencial. Prepárate con las habilidades más nuevas y demandadas a un menor precio de lo que gastarías regularmente.";
            ViewBag.MetaKeywords = "psicología, clinica, menor precio, tecnologías, servicios, consulta, online, presencial, psicoterapia, familiar, pareja, infantil, adolescentes, terapia, adultos, asesoramiento, educación, profesional, capacitación, docente, evaluación, duelo, orientacion vocacional, orientación, pruebas, anciedad, ansiedad, rehabilitación, terapia, breve, cognitivo conductual, pareja, test machover, consulta subsecuente, en línea, presencial";
            ViewBag.MetaAuthor = "caam, dgarcia2105, didade";
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO usuarioDto)
        {
            try
            {
                //Guardar información en una sesión
                //HttpContext.Session.SetString("Usuario", "Dany");
                //HttpContext.Session.SetString("Usuario", "Dany"); 

                var resultDto = await usuarioService.LoginApi(usuarioDto);

                UsuarioProfile usuarioLogeado = new UsuarioProfile()
                {
                    Usuario = resultDto
                };
                //-----------------
                // Encrypt the ticket.
                string encTicket = JsonConvert.SerializeObject(usuarioLogeado);
                string encriptado = Com.Encryptor(encTicket);
                //var HttpCookie = new HttpResponse.Cookie(".AUTHCENTRAL", encriptado)
                //{
                //    Expires = DateTime.Now.AddSeconds(FormsAuthentication.Timeout.TotalSeconds),
                //    Secure = true
                //};
                HttpContext.Response.Cookies.Append(".AUTHCAAM", encriptado);
                //---------------------
                if (resultDto != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, resultDto.Rol.Descripcion.ToString()),
                        new Claim(ClaimTypes.Name, resultDto.NombreCompleto),
                        new Claim("NombreCompleto", resultDto.NombreCompleto),
                        new Claim("correo", !string.IsNullOrEmpty(resultDto.Correo) ? resultDto.Correo : ""),
                        new Claim("Id", resultDto.Id.ToString()),
                        new Claim("BearerToken", resultDto.BearerToken.ToString()),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)); //, isPersistent:false, lockoutOnFailure: false

                    //return Redirect("/Usuario/Index");
                    //return Redirect(ReturnUrl == null ? "/Usuario/Index" : ReturnUrl);
                }
                else
                {
                    //return View();
                }

                return Ok(new Result { Code = StatusCodes.Status200OK, Data = resultDto });

            }
            catch (ValidationException ex)
            {
                //var error = new ExceptionMessage(ex);
                //var a = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status400BadRequest, new Result { Code = StatusCodes.Status400BadRequest, Message = error.MessageException});

                //JResult.Value = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
                //new JsonResult() { Value = null };
            }
            catch (Exception ex)
            {
                var error = new ExceptionMessage(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, new Result { Code = StatusCodes.Status500InternalServerError, Message = error.MessageException });

                //var error = new ExceptionMessage(ex);
                //return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            }

            return JResult;

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}