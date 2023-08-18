using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MM.CAAM.Admin.Web.Controllers
{
    public class StudentsController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var claim = HttpContext.User.Claims.Where(claim => claim.Type == "BearerToken").FirstOrDefault();
            var valueClaim = claim.Value;


            //var claims = HttpContext.User.Identities.FirstOrDefault().Claims.ToList();

            return View();
        }
    }
}