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
                Title = "Caam: Atención Profesional en Psicología",
                Marca = "CAAM",
                Descripcion = "Psicología Profesional CAAM.",
                Eslogan = "Por una buena educación.",
                UrlRedSocialPrincipal = "https://www.facebook.com/psicologia.caam",
                TextRedSocialPrincipal = "facebook."
            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "La mejor atención psicológica profesional a un menor precio de lo que gastarias regularmente.",
                Keywords = "Profesional, Psicología, Niños, Adolecentes, Adultos, Pareja, Mejor Psicóloga, A tu alcance, A un menor precio, Xochicalco, UABC, Certificado",
                Author = "Psicología CAAM, Psicologia-CAAM.com, DGarcia2105.com.mx"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/psicologia.caam",
                    Texto = "facebook."
                } 
            };
            #endregion

            #region Direccion
            homeDto.Contacto = new ContactoDto()
            {
                Ciudad = "Mexicali",
                Estado = "Baja California",
                Direccion = "Magisterio, Av. Sta Gertrudis. San Vizcaino",
                Tel = "",
                Cel = "686.589.5638",
                Correo = "",
                CorreoMarketing = "Daniel2105Oficial@gmail.com"
            };
            #endregion

            #region InfoHome
            homeDto.ListInfoHome = new List<InfoHomeDto>()
            {
                new InfoHomeDto()
                {
                    Titulo = "Infantil",
                    Contenidos = new List<string>()
                    {
                        "El psicólogo infantil se encarga del proceso de evaluación y diagnóstico de niños y adolescentes. Es el profesional capacitado para diagnosticar los trastornos del desarrollo de índole psicológica que pueden aparecer en este periodo evolutivo, desde el autismo hasta las dificultades de aprendizaje."
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Familiar",
                    Contenidos = new List<string>()
                    {
                        "¿Cómo se aplica la psicologia familiar?"
                        ,"Resultado de imagen para psicologia familiar La psicología familiar analiza y trata de resolver esos conflictos que se plantean en el grupo familiar. En la psicología familiar se estudian las familias como sistemas y se analizan comportamientos, patrones de comunicación y respuestas emocionales entre los miembros del grupo familiar."
                        ,"¿Por qué es importante la psicología en la familia?"
                        ,"Función de apoyo y protección psicosocial: Ejerce un efecto protector y estabilizador frente a los trastornos mentales, la familia facilita la adaptación de sus miembros a las nuevas circunstancias en consonancia con el entorno social. Según Nathan W."
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Pareja",
                    Contenidos = new List<string>()
                    {
                        "¿Cómo saber si tengo que ir a terapia de pareja?",
                        "Los principales motivos por los que se recurre a una Terapia de Pareja son: ",
                        "1. Dificultades en la sexualidad, disfunciones sexuales o desacuerdos en la frecuencia de las relaciones.",
                        "2. Monotonía y aburrimiento en la relación de pareja.",
                        "3. Problemas en la comunicación.",
                        "4. Infidelidades.",
                        "5. Celos y desconfianza en la pareja."
                    }
                },
                new InfoHomeDto()
                {
                    Titulo = "Individual",
                    Contenidos = new List<string>()
                    {
                        "La terapia individual se suele emplear para trabajar los problemas de ansiedad, la depresión, la inseguridad personal, la baja autoestima, la toma de decisiones, el autocontrol de las emociones, la sensación de estancamiento en la vida (en el área sentimental, la vida laboral, las relaciones con otras personas del entorno, etc.), y los problemas sexuales, en aquellos casos en los que no se tiene una pareja o ésta no quiere participar en la terapia."
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
                Descripcion = "Psicología Profesional CAAM."
            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "La mejor atención psicológica profesional a un menor precio de lo que gastarias regularmente.",
                Keywords = "Profesional, Psicología, Niños, Adolecentes, Adultos, Pareja, Mejor Psicóloga, A tu alcance, A un menor precio, Xochicalco, UABC, Certificado",
                Author = "Psicología CAAM, Psicologia-CAAM.com, DGarcia2105.com.mx"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/psicologia.caam",
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
                Title = "Caam: Atención Profesional en Psicología",
                Marca = "CAAM",
                Descripcion = "Psicología Profesional CAAM.",
                Eslogan = "Por una buena educación.",
                UrlRedSocialPrincipal = "https://www.facebook.com/psicologia.caam",
                TextRedSocialPrincipal = "facebook."

            };

            #region Meta Html
            homeDto.MetaHtml = new MetaHtmlDto()
            {
                Description = "La mejor atención psicológica profesional a un menor precio de lo que gastarias regularmente.",
                Keywords = "Profesional, Psicología, Niños, Adolecentes, Adultos, Pareja, Mejor Psicóloga, A tu alcance, A un menor precio, Xochicalco, UABC, Certificado",
                Author = "Psicología CAAM, Psicologia-CAAM.com, DGarcia2105.com.mx"
            };
            #endregion

            #region Redes Sociales
            homeDto.ListRedSocial = new List<RedSocialDto>()
            {
                new RedSocialDto()
                {
                    Url = "https://www.facebook.com/psicologia.caam",
                    Texto = "facebook."
                }
            };
            #endregion

            #region Direccion
            homeDto.Contacto = new ContactoDto()
            {
                Ciudad = "Mexicali",
                Estado = "Baja California",
                Direccion = "Magisterio, Av. Sta Gertrudis. San Vizcaino",
                Tel = "",
                Cel = "686.589.5638",
                Correo = "",
                CorreoMarketing = "Daniel2105Oficial@gmail.com"
            };
            #endregion

            return View(homeDto);
        }
    }
}