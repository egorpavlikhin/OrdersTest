using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace OrdersTest
{
    public static class IocContainer
    {
        private static IWindsorContainer container;

        public static void Setup(HttpConfiguration configuration)
        {
            container = new WindsorContainer().Install(FromAssembly.This());

            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));

            configuration.DependencyResolver = new WindsorDependencyResolver(container.Kernel);
        }
    }
}