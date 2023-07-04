﻿using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Servicios.Test;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ITestService TestService;

        public UsuarioController(ITestService testService)
        {
            TestService = testService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            Post post = new Post()
            {
                userId = 50,
                body = "Hola como estas",
                title = "Titulo de saludo"
            };
            var postResponse = await TestService.PostTest(post);
            var postResponse2 = await TestService.PutTest(post);
            var postResponse3 = await TestService.DeleteTest(post);


            string FirstName = usuarioCreacionDTO.Nombre;

            return RedirectToAction("Index");
        }
    }
}