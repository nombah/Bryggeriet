using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ystadbryggeriet.Models;

namespace Ystadbryggeriet.Areas.Admin.Controllers
{
    [Authorize]
    public class HappeningsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Happenings
        public ActionResult Index()
        {
            return View(db.Happenings.ToList());
        }

        // GET: Admin/Happenings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Happenings happenings = db.Happenings.Find(id);
            if (happenings == null)
            {
                return HttpNotFound();
            }
            return View(happenings);
        }

        // GET: Admin/Happenings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Happenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HappeningsId,Title,Information,Date")] Happenings happenings)
        {
            if (ModelState.IsValid)
            {
                db.Happenings.Add(happenings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(happenings);
        }

        // GET: Admin/Happenings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Happenings happenings = db.Happenings.Find(id);
            if (happenings == null)
            {
                return HttpNotFound();
            }
            return View(happenings);
        }

        // POST: Admin/Happenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HappeningsId,Title,Information,Date")] Happenings happenings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(happenings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(happenings);
        }

        // GET: Admin/Happenings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Happenings happenings = db.Happenings.Find(id);
            if (happenings == null)
            {
                return HttpNotFound();
            }
            return View(happenings);
        }

        // POST: Admin/Happenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Happenings happenings = db.Happenings.Find(id);
            db.Happenings.Remove(happenings);
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
