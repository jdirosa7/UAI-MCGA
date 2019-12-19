using MCGA_Safari.Entities;
using MCGA_Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA_Safari.UI.Web.Controllers
{
    public class PriceController : Controller
    {
        ServiceTypeProcess dbServiceType = new ServiceTypeProcess();
        PriceProcess db = new PriceProcess();

        public static ServiceType serviceType = null;
        // GET: Price
        public ActionResult Index()
        {
            return View();
        }

        // GET: Price/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Price/Create
        public ActionResult Create(int? id)
        {
            serviceType = dbServiceType.Find(id.Value);
            ViewBag.ServiceType = serviceType;
            
            return View();
        }

        // POST: Price/Create
        [HttpPost]
        public ActionResult Create(Price price)
        {
            try
            {
                // TODO: Add insert logic here
                price.ServiceTypeId = serviceType.Id;
                db.Add(price);
                return RedirectToAction("Index", "ServiceType");
            }
            catch
            {
                return View();
            }
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Price/Edit/5
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

        // GET: Price/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Price/Delete/5
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
