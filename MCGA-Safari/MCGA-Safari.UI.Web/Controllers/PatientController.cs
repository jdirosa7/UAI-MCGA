using MCGA_Safari.Entities;
using MCGA_Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCGA_Safari.UI.Web.Controllers
{
    public class PatientController : Controller
    {
        PatientProcess db = new PatientProcess();
        ClientProcess dbClient = new ClientProcess();
        SpecieProcess dbSpecie = new SpecieProcess();
        
        // GET: Patient
        [Route("pacientes", Name = "PatientControllerRouteIndex")]
        public ActionResult Index()
        {
            ViewBag.ClientsList = new SelectList(dbClient.ToList(), "Id", "Name");
            ViewBag.SpeciesList = new SelectList(dbSpecie.ToList(), "Id", "Nombre");
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.Clients = new SelectList(dbClient.ToList(), "Id", "Name");
            ViewBag.Species = new SelectList(dbSpecie.ToList(), "Id", "Nombre");
            return View();
        }

        public ActionResult GetData()
        {
            List<Patient> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var patient = db.Find(id);
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Patient patient)
        {
            Patient dataPatient = new Patient();
            dataPatient.Name = patient.Name;
            dataPatient.SpecieId = patient.SpecieId;
            dataPatient.BirthDate = patient.BirthDate;
            dataPatient.ClientId = patient.ClientId;
            dataPatient.Observation = patient.Observation;

            if (patient.Id > 0)
            {
                dataPatient.Id = patient.Id;
                db.Update(dataPatient);
            }
            else
                db.Add(dataPatient);

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(int? id)
        {
            if (id > 0)
            {
                db.Delete(id.Value);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Patient paciente = db.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }

                return View(paciente);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            var clientes = dbClient.ToList();
            var especies = dbSpecie.ToList();

            ViewBag.ClientId = new SelectList(clientes, "Id", "Name");
            ViewBag.SpecieId = new SelectList(especies, "Id", "Nombre");
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patient paciente)
        {
            try
            {
                var model = db.Add(paciente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            Patient paciente = db.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient paciente)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(paciente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            Patient paciente = db.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }

            return View(paciente);
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Patient paciente)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
