using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrdersTest.DataAccess;

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
            User.Identity.GetUserId();
            return View();
        }

        // GET: Procurement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Procurement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procurement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Procurement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Procurement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Procurement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Procurement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
