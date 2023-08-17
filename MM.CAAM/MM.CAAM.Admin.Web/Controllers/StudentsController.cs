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

namespace MM.CAAM.Admin.Web.Controllers
{
    public class StudentsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}