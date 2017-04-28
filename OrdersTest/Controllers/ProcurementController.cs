using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdersTest.DataAccess;

namespace OrdersTest.Controllers
{
    public class ProcurementController : Controller
    {
        private IProcurementRepository procurementRepository;

        public ProcurementController(IProcurementRepository procurementRepository)
        {
            this.procurementRepository = procurementRepository ?? throw new ArgumentNullException(nameof(procurementRepository));
        }

        // GET: Procurement
        public ActionResult Index()
        {
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
