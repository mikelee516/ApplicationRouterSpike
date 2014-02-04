using FoodTrackerWebApi.Controllers;
using FoodTrackerWebApi.Data;
using FoodTrackerWebApi.Repositories;
using Microsoft.Practices.Unity;
using System;

namespace FoodTrackerWebApi
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
            unityContainer.RegisterType<IFoodTrackerContext, FoodTrackerContext>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(
                        "Name=FoodTrackerContext"
                    ));
        }
    }
}
