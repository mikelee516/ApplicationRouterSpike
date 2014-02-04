using ApplicationRouter.Controllers;
using ApplicationRouter.Data;
using ApplicationRouter.Repositories;
using Microsoft.Practices.Unity;
using System;

namespace ApplicationRouter
{
    public static class UnityBootstrap
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            // Add your register logic here...
            unityContainer.RegisterType<Startup>();
            unityContainer.RegisterType<IAppRouterContext, AppRouterContext>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(
                        "Name=AppRouterContext"
                    ));
            unityContainer.RegisterType<EndpointRegistrationRepository>();
            unityContainer.RegisterType<EndpointController>();
        }
    }
}
