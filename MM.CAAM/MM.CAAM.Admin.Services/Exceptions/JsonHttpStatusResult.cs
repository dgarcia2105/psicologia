using System.Net;
using System.Web.Mvc;

namespace MM.CAAM.Admin.Services.Exceptions
{
    public class JsonHttpStatusResult : JsonResult
    {
        private readonly HttpStatusCode HttpStatusCode;

        public JsonHttpStatusResult(object data, HttpStatusCode httpStatusCode)
        {
            Data = data;
            HttpStatusCode = httpStatusCode;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode;
            base.ExecuteResult(context);
        }
    }
}