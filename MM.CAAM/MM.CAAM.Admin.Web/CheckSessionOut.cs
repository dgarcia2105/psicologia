using Microsoft.AspNetCore.Mvc.Filters;

namespace MM.CAAM.Admin.Web
{
    //[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionOut : IActionFilter //ActionFilterAttribute
    {
        private readonly ILogger<CheckSessionOut> logger;   
        public CheckSessionOut(ILogger<CheckSessionOut> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Antes de ejecutar la ");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //logger.LogInformation("Despúes de ejecutar la ");
            throw new NotImplementedException();
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
