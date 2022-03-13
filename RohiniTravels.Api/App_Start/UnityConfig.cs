using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace RohiniTravels.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.LoadConfiguration("Repository");
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}