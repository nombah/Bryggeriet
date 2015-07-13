using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ystadbryggeriet.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Ystadbryggeriet.Areas.Admin.Controllers
{
    [Authorize]
    public class CalendarEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CalendarEvents
        public ActionResult Index()
        {
            var calendarEvents = db.CalendarEvents.Include(c => c.user);
            ViewBag.UserName = "Kalle";
            return View(calendarEvents.ToList());
        }

        // GET: Admin/CalendarEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        public JsonResult GetEvents()
        {
            var Events = db.CalendarEvents.Select(x => new { id = x.CalendarEventId,classname = x.user.Name, starttime = x.StartTime,endtime = x.EndTime,allDay = x.IsAllDay, title = x.user.Name}).ToList();
            var eventt = new List<dynamic>();
            foreach(var EventDate in Events)

            {
                eventt.Add(new { id = EventDate.id, start = EventDate.starttime.ToString("yyyy-MM-ddTHH:mm"), end = EventDate.endtime.ToString("yyyy-MM-ddTHH:mm"), allDay = EventDate.allDay, title = EventDate.title, className = EventDate.classname });
            }
            return Json(eventt, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/CalendarEvents/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Admin/CalendarEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalendarEventId,UserId,StartTime,EndTime,IsAllDay")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                db.CalendarEvents.Add(calendarEvent);
                db.SaveChanges();
                return RedirectToAction("create");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", calendarEvent.UserId);
            return View(calendarEvent);
        }

        // GET: Admin/CalendarEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", calendarEvent.UserId);
            return View(calendarEvent);
        }

        // POST: Admin/CalendarEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendarEventId,UserId,StartTime,EndTime,IsAllDay")] CalendarEvent calendarEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", calendarEvent.UserId);
            return View(calendarEvent);
        }

        // GET: Admin/CalendarEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            if (calendarEvent == null)
            {
                return HttpNotFound();
            }
            return View(calendarEvent);
        }

        // POST: Admin/CalendarEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarEvent calendarEvent = db.CalendarEvents.Find(id);
            db.CalendarEvents.Remove(calendarEvent);
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
