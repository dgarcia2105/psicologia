using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Web.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class HomeController : Controller
    { 
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
        {
            if (username == "b" || password == "2")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("correo", "correo"),
                    new Claim("Id", "Id"),
                    new Claim("BearerToken", "BearerToken: 123456789"),
                };

                //var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)); //, isPersistent:false, lockoutOnFailure: false

                return Redirect(ReturnUrl == null ? "/Students" : ReturnUrl);
            }
            else
            {
                return View();
            }
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}


    }
}