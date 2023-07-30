using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Admin.Web.Models;
using System.Diagnostics;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class LogginController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LogginController(ILogger<HomeController> logger)
        {
            _logger = logger; 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}