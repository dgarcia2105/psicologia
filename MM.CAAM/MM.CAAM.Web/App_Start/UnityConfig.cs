using MM.CAAM.Admin.Services;
using MM.CAAM.Admin.Services.Servicios.Test;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace MM.CAAM.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //var ProveedorBD = int.Parse(ConfigurationManager.AppSettings["ProveedorBD"]);
            //var ConexionBD = ConfigurationManager.AppSettings["ConexionBD"];

            var ApiKeyCentralActuarios = ConfigurationManager.AppSettings["ApiKeyCaam"];
            var BaseUrlApiCentralActuarios = ConfigurationManager.AppSettings["BaseUrlWebApiCaam"];

            container.RegisterType<IRESTService, RESTService>(new InjectionConstructor(ApiKeyCentralActuarios, BaseUrlApiCentralActuarios));
            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUsuarioService, UsuarioService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}