using System;
using System.Web.Mvc;

namespace OrdersTest.DataAccess
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                this.UnitOfWork.Commit();
            }
            finally
            {
                
            }
        }
    }
}