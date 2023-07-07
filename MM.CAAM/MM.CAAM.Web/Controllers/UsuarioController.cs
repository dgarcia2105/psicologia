using MM.CAAM.Admin.DTOs;
using MM.CAAM.Admin.DTOs.Objects;
using MM.CAAM.Admin.DTOs.Request;
using MM.CAAM.Admin.DTOs.Test;
using MM.CAAM.Admin.Services.Exceptions;
using MM.CAAM.Admin.Services.Servicios.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class UsuarioController : Controller
    {
        //private readonly ITestService TestService;

        public UsuarioController(ITestService testService)
        {
            //TestService = testService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarUsuario()
        {
            List<GeneroRequest> Generos = new List<GeneroRequest>()
            {
                new GeneroRequest() { Id = 1, Genero = "M" },
                new GeneroRequest() { Id = 2, Genero = "F" }
            };
            var GenerosSelect = new SelectList(
                                        items: Generos,
                                        dataValueField: nameof(GeneroRequest.Genero),
                                        dataTextField: nameof(GeneroRequest.Genero));
            ViewBag.Generos = GenerosSelect;

            List<RolDTO> Roles = new List<RolDTO>()
            {
                new RolDTO() { Id = 1, Rol = "1" },
                new RolDTO() { Id = 2, Rol = "2" }
            };
            var RolesSelect = new SelectList(
                                        items: Roles,
                                        dataValueField: nameof(RolDTO.Rol),
                                        dataTextField: nameof(RolDTO.Rol));
            ViewBag.Roles = RolesSelect;

            return View();
        }

        [HttpPost] //attribute to get posted values from HTML Form
        public async Task<ActionResult> CrearUsuario(UsuarioDTO usuarioDTO, HttpPostedFileBase PerfilNombreArchivo)
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
            //try
            //{
            //    if (usuarioDto.RolId < 0)
            //        throw new ValidationException("El id rol es requerido.");
            //    if (usuarioDto.CentralId < 0)
            //        throw new ValidationException("La central es requerida.");

            //    if (PerfilNombreArchivo != null && PerfilNombreArchivo.ContentLength > 0)
            //    {
            //        var fullPath = Path.Combine(usuarioDto.PathFotosActuarios, PerfilNombreArchivo.FileName);
            //        var fileName = Com.RenombrarSiExisteArchivo(fullPath);
            //        PerfilNombreArchivo.SaveAs(Path.Combine(usuarioDto.PathFotosActuarios, fileName));

            //        usuarioDto.PerfilNombreArchivo = fileName;
            //    }
            //    else
            //        usuarioDto.PerfilNombreArchivo = null;

            //    UsuarioService.InsertUsuario(usuarioDto);

            //    // Exito
            //    JResult.Data = new Result { Code = (int)HttpStatusCode.OK };
            //}
            //catch (ValidationException ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    JResult.Data = new Result { Code = (int)HttpStatusCode.BadRequest, Message = ex.Message };
            //}
            //catch (Exception ex)
            //{
            //    var error = new ExceptionMessage(ex);
            //    return new JsonHttpStatusResult(error.MessageException, HttpStatusCode.InternalServerError);
            //}

            //return JResult;

            return null;
        }
    }
}