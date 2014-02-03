using Microsoft.Owin.Hosting;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;
using Unity.SelfHostWebApiOwin;

namespace ApplicationRouter
{
    public class Startup
    {
        private static readonly IUnityContainer _container = UnityHelpers.GetConfiguredContainer();

        public static void StartServer()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var baseAddress = string.Format("http://localhost:{0}/", port);

            var startup = _container.Resolve<Startup>();
            IDisposable webApplication = WebApp.Start(baseAddress, startup.Configuration);


            try
            {
                Console.WriteLine("Started...");


                Console.ReadKey();
            }
            finally
            {
                webApplication.Dispose();
            }
        }


        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        //public void Configuration(IAppBuilder appBuilder)
        //{
        //    // Configure Web API for self-host. 
        //    var config = new HttpConfiguration();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );

        //    appBuilder.UseWebApi(config);
        //}

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();


            // Add Unity DependencyResolver
            config.DependencyResolver = new UnityDependencyResolver(UnityHelpers.GetConfiguredContainer());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API routes
            //config.MapHttpAttributeRoutes();

            appBuilder.UseWebApi(config);
        }

    }
}
