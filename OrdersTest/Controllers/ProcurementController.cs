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
        private IProcurementRepository procurementRepository;
        private IUserProcurementRepository userProcurementRepository;

        public ProcurementController(IProcurementRepository procurementRepository, IUserProcurementRepository userProcurementRepository)
        {
            this.procurementRepository = procurementRepository ?? throw new ArgumentNullException(nameof(procurementRepository));
            this.userProcurementRepository = userProcurementRepository ?? throw new ArgumentNullException(nameof(userProcurementRepository));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
