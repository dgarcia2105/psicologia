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

namespace MM.CAAM.Admin.Web.Controllers
{
    public class BuscarController : BaseController
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;

        public BuscarController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
        }

        public IActionResult Index(string search = "")
        {
            #region Meta
            ViewBag.Title = "Caam: Centro psicológico de aprendizaje profesional";
            ViewBag.MetaDescripcion = "Únete hoy a Caam, el centro psicológico profesional de educación en línea y presencial. Prepárate con las habilidades más nuevas y demandadas a un menor precio de lo que gastarías regularmente.";
            ViewBag.MetaKeywords = "psicología, clinica, menor precio, tecnologías, servicios, consulta, online, presencial, psicoterapia, familiar, pareja, infantil, adolescentes, terapia, adultos, asesoramiento, educación, profesional, capacitación, docente, evaluación, duelo, orientacion vocacional, orientación, pruebas, anciedad, ansiedad, rehabilitación, terapia, breve, cognitivo conductual, pareja, test machover, consulta subsecuente, en línea, presencial";
            ViewBag.MetaAuthor = "caam, dgarcia2105, didade";
            #endregion

            return View();
        }
         
    }
}