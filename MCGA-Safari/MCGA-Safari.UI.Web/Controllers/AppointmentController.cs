using MCGA_Safari.Entities;
using MCGA_Safari.UI.Process;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MCGA_Safari.Entities.Appointment;

namespace MCGA_Safari.UI.Web.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentProcess db = new AppointmentProcess();
        PatientProcess dbPatient = new PatientProcess();
        ClientProcess dbClient = new ClientProcess();
        ServiceTypeProcess dbServiceType = new ServiceTypeProcess();
        RoomProcess dbRoom = new RoomProcess();
        DoctorProcess dbDoctor = new DoctorProcess();
        PriceProcess dbPrice = new PriceProcess();
        MovementTypeProcess dbMovementType = new MovementTypeProcess();
        MovementProcess dbMovement = new MovementProcess();


        // GET: Appointment
        [Route("turnos", Name = "AppointmentControllerRouteIndex")]
        public ActionResult Index()
        {
            ViewBag.ServiceTypesList = new SelectList(dbServiceType.ToList(), "Id", "Name");
            ViewBag.PatientsList = new SelectList(dbPatient.ToList(), "Id", "Name");
            ViewBag.RoomsList = new SelectList(dbRoom.ToList(), "Id", "Name");
            ViewBag.DoctorsList = new SelectList(dbDoctor.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.ServiceTypes = new SelectList(dbServiceType.ToList(), "Id", "Name");
            ViewBag.Patients = new SelectList(dbPatient.ToList(), "Id", "Name");
            ViewBag.Rooms = new SelectList(dbRoom.ToList(), "Id", "Name");
            ViewBag.Doctors = new SelectList(dbDoctor.ToList(), "Id", "Name");
            return View();
        }

        public ActionResult Calendar()
        {
            List<Appointment> apps = db.ToList();

            var json = ToJSON(ToCalendarModel(apps));

            ViewBag.Appointments = json;
            return View();
        }

        public static string ToJSON(List<CalendarItem> obj)
        {
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(obj);
        }

        public ActionResult GetData()
        {
            List<Appointment> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var appointment = db.Find(id);
            return Json(appointment, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Appointment appointment)
        {
            Appointment dataAppointment = new Appointment();
            dataAppointment.Date = appointment.Date;
            dataAppointment.DoctorId = appointment.DoctorId;
            dataAppointment.PatientId = appointment.PatientId;
            dataAppointment.ServiceTypeId = appointment.ServiceTypeId;
            dataAppointment.RoomId = appointment.RoomId;
            if(appointment.Status == null)
            {
                dataAppointment.Status = Statuses.Reservado.ToString();
            }
            else
            {
                dataAppointment.Status = appointment.Status;
            }

            if (appointment.Id > 0)
            {
                dataAppointment.UpdatedBy = User.Identity.GetUserId();
                dataAppointment.UpdatedDate = DateTime.Today;
                dataAppointment.Id = appointment.Id;
                db.Update(dataAppointment);
            }
            else
            {
                dataAppointment.CreatedBy = User.Identity.GetUserId();
                dataAppointment.CreatedDate = DateTime.Today;
                db.Add(dataAppointment);
            }

            if(dataAppointment.Status == "Confirmado")
            {
                //Con el Tipo de servicio y la fecha de hoy, busco el precio
                //Luego busco el tipo de movimiento deudor y obtengo el multiplicador
                //Creo un movimiento con fecha, cliente, tipo de movimiento y valor
                MovementType movementType = dbMovementType.Find("Deudor");
                Price price = dbPrice.Find(dataAppointment.ServiceTypeId, DateTime.Today);                
                Patient patient = dbPatient.Find(dataAppointment.PatientId);
                Movement movement = new Movement {
                    ClientId = patient.ClientId,
                    Date = DateTime.Today,
                    MovementTypeId = movementType.Id,
                    Value = price.Value * movementType.Multiplier
                };
                dbMovement.Add(movement);
            }
            else
            {
                if(dataAppointment.Status == "Realizado")
                {
                    //Con el Tipo de servicio y la fecha de hoy, busco el precio
                    //Luego busco el tipo de movimiento acreedor y obtengo el multiplicador
                    //Creo un movimiento con fecha, cliente, tipo de movimiento y valor
                    Price price = dbPrice.Find(dataAppointment.ServiceTypeId, DateTime.Today);
                    MovementType movementType = dbMovementType.Find("Acreedor");
                    Patient patient = dbPatient.Find(dataAppointment.PatientId);
                    Movement movement = new Movement
                    {
                        ClientId = patient.ClientId,
                        Date = DateTime.Today,
                        MovementTypeId = movementType.Id,
                        Value = price.Value * movementType.Multiplier
                    };
                    dbMovement.Add(movement);
                }
            }

            

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(int id)
        {
            if (id > 0)
            {
                Appointment app = new Appointment();
                app.Id = id;
                app.Status = Statuses.Cancelado.ToString();
                app.Deleted = true;
                app.DeletedBy = User.Identity.GetUserId();
                app.DeletedDate = DateTime.Today;
                db.Delete(app);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        public static List<CalendarItem> ToCalendarModel(List<Appointment> appointments)
        {
            List<CalendarItem> calendarItems = new List<CalendarItem>();

            appointments.ForEach(app =>
            {
                calendarItems.Add(new CalendarItem
                {
                    Id = app.Id,
                    title = "Turno",
                    description = "Paciente: " + app.Patient.Name + " con Doctor: " + app.Doctor.LastName,
                    start = app.Date.ToString("yyyy-MM-ddThh:mm:ss"),
                    end = app.Date.ToString("yyyy-MM-ddThh:mm:ss"),
                });
            });            

            return calendarItems;
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = User.Identity.GetUserId();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
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

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
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
