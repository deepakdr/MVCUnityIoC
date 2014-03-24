using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcIoC.Models;
using Unity.Mvc4;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace MvcIoC
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            //Read the unity configuration from web.config

            UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;

            section.Configure(container, "Default");

        }
    }
}