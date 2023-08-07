using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MM.CAAM.Gestion.DTO.DTOs.Request;
using MM.CAAM.Gestion.DTO.DTOs;
using MM.CAAM.Web.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios.Test;

namespace MM.CAAM.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService UsuarioService;

        private readonly ITestService TestService;

        public UsuarioController(ITestService testService, IUsuarioService usuarioService)
        {
            this.UsuarioService = usuarioService;
            TestService = testService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            //List<GeneroRequest> Generos = new List<GeneroRequest>()
            //{
            //    new GeneroRequest() { Id = 1, Genero = "M" },
            //    new GeneroRequest() { Id = 2, Genero = "F" }
            //};
            //var GenerosSelect = new SelectList(
            //                            items: Generos,
            //                            dataValueField: nameof(GeneroRequest.Genero),
            //                            dataTextField: nameof(GeneroRequest.Genero));
            //ViewBag.Generos = GenerosSelect;

            //List<RolDTO> Roles = new List<RolDTO>()
            //{
            //    new RolDTO() { Id = 1, Rol = "1" },
            //    new RolDTO() { Id = 2, Rol = "2" }
            //};

            //var RolesSelect = new SelectList(
            //                            items: Roles,
            //                            dataValueField: nameof(RolDTO.Rol),
            //                            dataTextField: nameof(RolDTO.Rol));


            //ViewBag.Roles = RolesSelect;

            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioCreacionDTO usuarioCreacionDto) //, HttpPostedFileBase PerfilNombreArchivo
        {
            //Post post = new Post()
            //{
            //    userId = 50,
            //    body = "Hola como estas",
            //    title = "Titulo de saludo"
            //};
            //var postResponse = await TestService.PostTest(post);
            //var postResponse2 = await TestService.PutTest(post);
            //var postResponse3 = await TestService.DeleteTest(post);


            //string FirstName = usuarioCreacionDTO.Nombre;

            //return RedirectToAction("Index");

            ///////////////////////////////////////////////////////////////////////////
            try
            {

                //TMP
                //if (PerfilNombreArchivo != null && PerfilNombreArchivo.ContentLength > 0)
                //{
                //    var fullPath = Path.Combine(usuarioDto.PathFotosActuarios, PerfilNombreArchivo.FileName);
                //    var fileName = Com.RenombrarSiExisteArchivo(fullPath);
                //    PerfilNombreArchivo.SaveAs(Path.Combine(usuarioDto.PathFotosActuarios, fileName));

                //    usuarioDto.PerfilNombreArchivo = fileName;
                //}
                //else
                //    usuarioDto.PerfilNombreArchivo = null;

                var a = await UsuarioService.InsertUsuario(usuarioCreacionDto);

                //JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            }
            catch (ValidationException ex)
            {
                var error = new ExceptionMessage(ex);
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