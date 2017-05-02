using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrdersTest.DataAccess;
using OrdersTest.Models;

namespace OrdersTest.Controllers
{
    [Authorize]
    [RoutePrefix("procurement")]
    public class ProcurementController : Controller
    {
        public ProcurementController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
