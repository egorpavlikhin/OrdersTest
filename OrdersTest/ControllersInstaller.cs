﻿using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OrdersTest.DataAccess;

namespace OrdersTest
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IActionInvoker>().ImplementedBy<WindsorActionInvoker>().LifeStyle.Transient);

            container.Register(
                Component.For<OrdersTestContext, OrdersTestContext>().LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly()
                .InSameNamespaceAs<ProcurementRepository>()
                .WithService.AllInterfaces()
                .LifestylePerWebRequest());
        }
    }
}