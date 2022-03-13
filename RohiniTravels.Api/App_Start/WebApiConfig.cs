using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;

namespace RohiniTravels.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes


            //var container = new UnityContainer();

            //// register all your components with the container here
            //// it is NOT necessary to register your controllers

            //// e.g. container.RegisterType<ITestService, TestService>();
            //container.LoadConfiguration("Repository");
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
