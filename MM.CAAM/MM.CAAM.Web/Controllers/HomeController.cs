using MM.CAAM.Admin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeDto = new HomeDto
            {
                Title = "Sastre Campanario: Sastre Profesional",
                Marca = "Sastre Campanario",
                Descripcion = "Sastre Profesional Campanario.",
                Eslogan = "ARREGLO DE ROPA PARA TODA LA FAMILIA.",
                UrlRedSocialPrincipal = "https://www.facebook.com/sastrecampanario",
                TextRedSocialPrincipal = "facebook."
            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "Sastre profesional a un menor costo de lo que gastarias regularmente",
                Keywords = "Prefiera la sastreria",
                Author = "Sastre Campanario"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/sastrecampanario",
                    Texto = "facebook."
                } 
            };
            #endregion

            #region Direccion
            homeDto.Contacto = new ContactoDto()
            {
                Ciudad = "Mexicali",
                Estado = "Baja California",
                Direccion = "Avenida concepción número 20, Frac. El campanario",
                Tel = "",
                Cel = "686.161.7979",
                Correo = "",
                CorreoMarketing = "Daniel2105Oficial@gmail.com"
            };
            #endregion

            #region InfoHome
            homeDto.ListInfoHome = new List<InfoHomeDto>()
            {
                new InfoHomeDto()
                {
                    Titulo = "Camisa",
                    Contenidos = new List<string>()
                    {
                        "Mangas",
                        "Largo",
                        "Hombros",
                        "Costados"
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Saco",
                    Contenidos = new List<string>()
                    {
                        "Mangas",
                        "Largo",
                        "Hombros",
                        "Costados"
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Vestidos",
                    Contenidos = new List<string>()
                    {
                        "Bastillas",
                        "Talle",
                        "Reducir",
                        "Tirantes"
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Pantalón",
                    Contenidos = new List<string>()
                    {
                        "Bastillas",
                        "Cintura",
                        "Angostados (entubados)",
                        "Cierres",
                        "Cipper"
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Chamarras",
                    Contenidos = new List<string>()
                    {
                        "Mangas",
                        "Cierres",
                        "Costados",
                        "Hombros"
                    }
                }
            };
            #endregion

            return View(homeDto);
        }

        public ActionResult About()
        {
            var homeDto = new HomeDto
            {
                Title = "Sastre Campanario: Sastre Profesional",
                Marca = "Sastre Campanario",
                Descripcion = "Sastre Profesional Campanario.",
                Eslogan = "ARREGLO DE ROPA PARA TODA LA FAMILIA.",
                UrlRedSocialPrincipal = "https://www.facebook.com/sastrecampanario",
                TextRedSocialPrincipal = "facebook."
            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "Sastre profesional a un menor costo de lo que gastarias regularmente",
                Keywords = "Prefiera la sastreria",
                Author = "Sastre Campanario"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/sastrecampanario",
                    Texto = "facebook."
                }
            };
            #endregion

            return View(homeDto);
        }

        public ActionResult Contact()
        {
            var homeDto = new HomeDto
            {
                Title = "Sastre Campanario: Sastre Profesional",
                Marca = "Sastre Campanario",
                Descripcion = "Sastre Profesional Campanario.",
                Eslogan = "ARREGLO DE ROPA PARA TODA LA FAMILIA.",
                UrlRedSocialPrincipal = "https://www.facebook.com/sastrecampanario",
                TextRedSocialPrincipal = "facebook."
            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "Sastre profesional a un menor costo de lo que gastarias regularmente",
                Keywords = "Prefiera la sastreria",
                Author = "Sastre Campanario"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/sastrecampanario",
                    Texto = "facebook."
                }
            };
            #endregion

            #region Direccion
            homeDto.Contacto = new ContactoDto()
            {
                Ciudad = "Mexicali",
                Estado = "Baja California",
                Direccion = "Avenida concepción número 20, Frac. El campanario",
                Tel = "",
                Cel = "686.161.7979",
                Correo = "",
                CorreoMarketing = "Daniel2105Oficial@gmail.com"
            };
            #endregion

            return View(homeDto);
        }
    }
}