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
    public class ProcurementController : Controller
    {
        private IProcurementRepository procurementRepository;
        private IUserProcurementRepository userProcurementRepository;

        public ProcurementController(IProcurementRepository procurementRepository, IUserProcurementRepository userProcurementRepository)
        {
            this.procurementRepository = procurementRepository ?? throw new ArgumentNullException(nameof(procurementRepository));
            this.userProcurementRepository = userProcurementRepository ?? throw new ArgumentNullException(nameof(userProcurementRepository));
        }

        // GET: Procurement
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Index(long id)
        {
            string userId = User.Identity.GetUserId();
            var procurement = await userProcurementRepository.GetById(userId, id);
            if (procurement == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Json(new { });
            }

            var jsonResult = Json(new { Item = procurement }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpGet]
        public async Task<JsonResult> List(int itemsPerPage, int pageNumber)
        {
            string userId = User.Identity.GetUserId();
            var procurementList = userProcurementRepository.GetByUserId(userId, (pageNumber - 1) * itemsPerPage, itemsPerPage);
            int count = await userProcurementRepository.CountAsync(userId);

            var jsonResult = Json(new { Items = procurementList, Count = count }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        [UnitOfWork]
        public async Task<JsonResult> Index(ProcurementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Json(new { });
            }

            string userId = User.Identity.GetUserId();
            var procurement = new Procurement
            {
                Name = model.Name,
                Description = model.Description,
                Total = model.Total
            };

            var userProcurement = new UserProcurement {UserId = userId, Procurement = procurement};

            procurementRepository.Add(procurement);
            userProcurementRepository.Add(userProcurement);

            var jsonResult = Json(new { Item = procurement }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPut]
        [UnitOfWork]
        public async Task<JsonResult> Index(long id, ProcurementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Json(new { });
            }

            string userId = User.Identity.GetUserId();
            var procurement = procurementRepository.GetById(id);
            if (procurement == null)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return Json(new { });
            }

            procurement.Name = model.Name;
            procurement.Description = model.Description;
            procurement.Total = model.Total;

            procurementRepository.Update(procurement);

            var jsonResult = Json(new { Item = procurement }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}
