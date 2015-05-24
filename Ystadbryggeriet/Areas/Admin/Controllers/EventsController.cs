using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ystadbryggeriet.Areas.Admin.Viewmodel;
using Ystadbryggeriet.Models;

namespace Ystadbryggeriet.Areas.Admin.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Events
        public ActionResult Index()
        {
            ViewBag.titles = "Schema o sånt jao";
            var EventViewmodel = new EventViewModel();
            EventViewmodel.eventz = db.events.ToList();
            return View(EventViewmodel);
        }
        
        // GET: Admin/Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Admin/Events/Create
        public ActionResult Create()
        {
            var EventViewmodel = new EventViewModel();
            EventViewmodel.users = new List<SelectListItem>();

            var users = db.Users.ToList();

            foreach(var user in users)
            {
                EventViewmodel.users.Add(new SelectListItem { Text = user.Name, Value = user.Id });
            }

            EventViewmodel.events = new events();

            return View(EventViewmodel);
            
        }
        public ActionResult GetMyEvents()
        {
            var e = new List<EventDto>();
            var Myevents = db.events.ToList();
            foreach (var k in Myevents) 
            {
               
            }
            return Json(e, JsonRequestBehavior.AllowGet);
        }
        // POST: Admin/Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventViewModel EventViewmodel)
        {
            if (ModelState.IsValid)
            {
                db.events.Add(EventViewmodel.events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(EventViewmodel);
        }

        // GET: Admin/Events/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "EventId,UserId,StartTime,EndTime,Date")] events @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Admin/Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            events @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        
        public JsonResult GetAllEvents()
        {
            return Json(new { title = "Free Pizza", allday = "false", borderColor = "#5173DA", color = "#99ABEA", textColor = "#000000", description = "<p>This is just a fake description for the Free Pizza.</p><p>Nothing to see!</p>", start = "2015-02-04T22:00:49", end = "2015-02-04", url = "http=//www.mikesmithdev.com/blog/worst-job-titles-in-internet-and-info-tech/" }, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            events @event = db.events.Find(id);
            db.events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
