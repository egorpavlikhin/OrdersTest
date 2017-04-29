using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using Castle.MicroKernel;
using Castle.Windsor;

namespace OrdersTest
{
    public class WindsorActionInvoker : AsyncControllerActionInvoker
    {
        readonly IKernel Kernel;

        public WindsorActionInvoker(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(
            ControllerContext controllerContext,
            IList<IActionFilter> filters,
            ActionDescriptor actionDescriptor,
            IDictionary<string, object> parameters)
        {
            foreach (IActionFilter actionFilter in filters)
            {
                Kernel.InjectProperties(actionFilter);
            }
            return base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
        }
    }
}