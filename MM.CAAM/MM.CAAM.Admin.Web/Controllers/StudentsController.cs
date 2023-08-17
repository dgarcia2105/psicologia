using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using MM.CAAM.Admin.Services.Servicios.Test;
using MM.CAAM.Admin.Web.Models;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using System.Diagnostics;
using System.Security.Claims;

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