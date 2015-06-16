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
    [Authorize(Roles ="Admin")]
    public class PageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Page
        public ActionResult Index()
        {
            ViewBag.titles = "Administrera hemsidan";
            return View(db.PageModels.ToList());
        }
        // GET: Admin/Page/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageModel pageModel = db.PageModels.Find(id);
            if (pageModel == null)
            {
                return HttpNotFound();
            }
            return View(pageModel);
        }

        // GET: Admin/Page/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,Title,PageText")] PageModel pageModel)
        {
            if (ModelState.IsValid)
            {
                db.PageModels.Add(pageModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageModel);
        }

        // GET: Admin/Page/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageModel pageModel = db.PageModels.Find(id);
            if (pageModel == null)
            {
                return HttpNotFound();
            }
            return View(pageModel);
        }

        // POST: Admin/Page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,Title,PageText")] PageModel pageModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }

        // GET: Admin/Page/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageModel pageModel = db.PageModels.Find(id);
            if (pageModel == null)
            {
                return HttpNotFound();
            }
            return View(pageModel);
        }

        // POST: Admin/Page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageModel pageModel = db.PageModels.Find(id);
            db.PageModels.Remove(pageModel);
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
