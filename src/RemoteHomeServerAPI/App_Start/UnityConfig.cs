using Microsoft.Practices.Unity;
using System.Web.Http;
using System;
using log4net;
using log4net.Repository.Hierarchy;
using RemoteHomeServerAPI.Services;
using UnityLog4NetExtension.Log4Net;

namespace RemoteHomeServerAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            RegisterTypes(container);
        }

        private static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IWashMachineService, WashMachineService>();
            container.RegisterType<IAudioService, AudioService>();
            container.AddNewExtension<Log4NetExtension>();
        }
    }
}