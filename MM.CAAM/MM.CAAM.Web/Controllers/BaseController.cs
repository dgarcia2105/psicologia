using System.Web.Mvc;

namespace MM.CAAM.Web.Controllers
{
    public class BaseController : Controller
    {
        public UsuarioProfile UsuarioProfile = null;
        public JsonResult JResult;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UsuarioProfile = User.GetMyIdentity()?.UsuarioProfile;

            if (UsuarioProfile != null)
            {
                TempData[nameof(UsuarioProfile.UsuarioDto.Id)] = UsuarioProfile.UsuarioDto.Id;
                TempData[nameof(UsuarioProfile.UsuarioDto.BearerToken)] = UsuarioProfile.UsuarioDto.BearerToken;
            }

            JResult = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            base.OnActionExecuting(filterContext);
        }
    }
}