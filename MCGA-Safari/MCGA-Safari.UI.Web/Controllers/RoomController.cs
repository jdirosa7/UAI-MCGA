using MCGA_Safari.Entities;
using MCGA_Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MCGA_Safari.Entities.Room;

namespace MCGA_Safari.UI.Web.Controllers
{
    public class RoomController : Controller
    {
        //IRoom db = new RoomService();

        RoomProcess db = new RoomProcess();
        //RoomComponent db = new RoomComponent();

        // GET: Room
        [Route("consultorios", Name = "RoomControllerRouteIndex")]
        public ActionResult Index()
        {
            ViewBag.RoomTypes = new SelectList(Enum.GetValues(typeof(Room.RoomTypes)), 1);
            return View();
            //var Rooms = db.ToList();
            //return View(Rooms);
        }

        public ActionResult CreatePartialView()
        {
            ViewBag.RoomTypes = new SelectList(Enum.GetValues(typeof(Room.RoomTypes)), RoomTypes.Recuperación);
            return PartialView("CreatePartialView");
        }

        //[HttpGet]
        //public PartialViewResult Edit(Int32 id)
        //{
        //    var Room = db.Find(id);
        //    return PartialView(Room);
        //}

        //[HttpPost]
        //public JsonResult Edit(Room Room)
        //{
        //    db.Update(Room);
        //    return Json(Room, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index2()
        {
            ViewBag.RoomTypes = new SelectList(Enum.GetValues(typeof(Room.RoomTypes)), RoomTypes.Recuperación);
            return View();
        }

        public ActionResult GetData()
        {
            List<Room> data = db.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataById(int id)
        {
            var Room = db.Find(id);
            return Json(Room, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostData(Room Room)
        {
            Room dataRoom = new Room();
            dataRoom.Name = Room.Name;
            dataRoom.RoomType = Room.RoomType;

            if (Room.Id > 0)
            {
                dataRoom.Id = Room.Id;
                db.Update(dataRoom);
            }
            else
                db.Add(dataRoom);

            return Json("success", JsonRequestBehavior.AllowGet);
            //if (ModelState.IsValid)
            //{

            //}

            //return Json("error", JsonRequestBehavior.DenyGet);
        }

        public JsonResult DeleteData(int? id)
        {
            if(id > 0)
            {
                db.Delete(id.Value);
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.DenyGet);
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Room Room = db.Find(id);
                if (Room == null)
                {
                    return HttpNotFound();
                }

                return View(Room);
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(Room Room)
        {
            try
            {
                db.Add(Room);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            Room Room = db.Find(id);
            if (Room == null)
            {
                return HttpNotFound();
            }

            return View(Room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room Room)
        {
            try
            {
                // TODO: Add update logic here
                db.Update(Room);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            Room Room = db.Find(id);
            if (Room == null)
            {
                return HttpNotFound();
            }

            return View(Room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Room Room)
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
