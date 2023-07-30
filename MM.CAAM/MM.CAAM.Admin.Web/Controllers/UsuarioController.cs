using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Web.Models;
using System.Diagnostics;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UsuarioController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}