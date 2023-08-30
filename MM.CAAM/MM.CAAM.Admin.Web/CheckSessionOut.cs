using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MM.CAAM.Gestion.DTO.DTOs;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Web;

namespace MM.CAAM.Admin.Web
{
    //[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionOut : IActionFilter //ActionFilterAttribute
    {
        private readonly ILogger<CheckSessionOut> logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckSessionOut(ILogger<CheckSessionOut> logger, IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region INIT 
            
            //UsuarioProfile usuarioLogeado = new UsuarioProfile()
            //{
            //    Usuario = new UsuarioDTO() { Id = 2/*, Name = "a", userName = "a"*/ }
            //};

            //// Encrypt the ticket.
            //string encTicket = JsonConvert.SerializeObject(usuarioLogeado);
            //CookieOptions options = new CookieOptions();
            //options.Expires = DateTime.Now.AddDays(1);
            //_httpContextAccessor.HttpContext.Response.Cookies.Append(".AUTHCENTRAL", encTicket, options);

            #endregion

            //var context2 = filterContext.HttpContext;

            /*
            var authCookie = _httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"];
            var cookieDesencriptada = Com.Decryptor(authCookie);
            var usuarioCokie = JsonConvert.DeserializeObject<UsuarioProfile>(cookieDesencriptada);
            //CustomIdentity userIdentity = new CustomIdentity("");
            CustomIdentity userIdentity2 = new CustomIdentity(usuarioCokie.Usuario.Id.ToString());
            */

            //var authCookie0 = _httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"];

            //_httpContextAccessor.HttpContext.Response.Cookies.Delete(".AUTHCENTRAL");





            //var cookie2 = _httpContextAccessor.HttpContext.Request.Cookies["2"];
            //var cookie3 = Com.Decryptor(_httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"]);
            //var authCookie = _httpContextAccessor.HttpContext.Request.Cookies[".AUTHCENTRAL"];
            //var cookieDesencriptada = Com.Decryptor(authCookie);
            //var usuarioCokie = JsonConvert.DeserializeObject<UsuarioProfile>(cookieDesencriptada);

            //--------------------

            //filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

            //#region LOGICA IF REDIRECT
            //var context = filterContext.HttpContext;

            //bool cerrarSesion = true;
            //if (context.User.GetType() == typeof(UsuarioPrincipal))
            //{
            //    if (context.User.GetMyIdentity().UsuarioProfile?.Usuario == null)
            //        cerrarSesion = true;
            //    else
            //        cerrarSesion = false;
            //}

            //if (context.User.GetType() != typeof(UsuarioPrincipal) || cerrarSesion)
            //{
            //    _httpContextAccessor.HttpContext.Response.Cookies.Delete(".AUTHCENTRAL");

            //    filterContext.Result = new RedirectToRouteResult(
            //        new RouteValueDictionary
            //        {
            //                            {"controller", "Home"},
            //                            {"action", "Index"}
            //        }
            //    );
            //}
            //#endregion 

            //logger.LogInformation("Antes de ejecutar la ");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logger.LogInformation("Despúes de ejecutar la ");
            //throw new NotImplementedException();
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var context = filterContext.HttpContext;

        //    bool cerrarSesion = true;
        //    if (context.User.GetType() == typeof(UsuarioPrincipal))
        //        if (context.User.GetMyIdentity().UsuarioProfile?.Usuario == null)
        //            cerrarSesion = true;
        //        else
        //            cerrarSesion = false;

        //    if (context.User.GetType() != typeof(UsuarioPrincipal) || cerrarSesion)
        //    {
        //        //FormsAuthentication.SignOut();
        //        context.Request.Cookies.Remove(".AUTHCENTRAL");
        //        if (!string.IsNullOrWhiteSpace(context.Request.RawUrl))
        //        {
        //            var redirectTo = FormsAuthentication.LoginUrl;
        //            redirectTo = string.Format("{0}?ReturnUrl={1}", redirectTo, HttpUtility.UrlEncode(context.Request.RawUrl));
        //            filterContext.Result = new RedirectResult(redirectTo);
        //            return;
        //        }
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

        //public override void OnActionExecuting(ActionExecutedContext filterContext)
        //{
        //    filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

        //    var context = filterContext.HttpContext;

        //    bool cerrarSesion = true;
        //    if (context.User.GetType() == typeof(UsuarioPrincipal))
        //        if (context.User.GetMyIdentity().UsuarioProfile?.Usuario == null)
        //            cerrarSesion = true;
        //        else
        //            cerrarSesion = false;

        //    if (context.User.GetType() != typeof(UsuarioPrincipal) || cerrarSesion)
        //    {
        //        //FormsAuthentication.SignOut();
        //        context.Request.Cookies.Remove(".AUTHCENTRAL");
        //        if (!string.IsNullOrWhiteSpace(context.Request.RawUrl))
        //        {
        //            var redirectTo = FormsAuthentication.LoginUrl;
        //            redirectTo = string.Format("{0}?ReturnUrl={1}", redirectTo, HttpUtility.UrlEncode(context.Request.RawUrl));
        //            filterContext.Result = new RedirectResult(redirectTo);
        //            return;
        //        }
        //    }
        //    base.OnActionExecuted(filterContext);
        //}
    }
}
