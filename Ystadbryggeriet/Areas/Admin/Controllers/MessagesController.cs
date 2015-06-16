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

namespace Ystadbryggeriet.Areas.Admin.Controllers
{

    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Messages
        public ActionResult Index()
        {
            
            var messages = db.Messages.Include(m => m.ReciverUser).Include(m => m.SenderUser);
            return View(messages.ToList().Where(item => item.ReciverUserID == User.Identity.GetUserId()).ToList());
        }

        // GET: Admin/Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            message.Read = true;
            db.Entry(message).State = EntityState.Modified;
            db.SaveChanges();
            return View(message);
        }

        // GET: Admin/Messages/Create
        public ActionResult Create()
        {
            ViewBag.ReciverUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Admin/Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,SenderUserID,ReciverUserID,Text")] Message message)
        {
 
            if (ModelState.IsValid)
            {
                message.SenderUserID = User.Identity.GetUserId();
                message.TimeStamp = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReciverUserID = new SelectList(db.Users, "Id", "Name", message.ReciverUserID);
            return View(message);
        }

        // GET: Admin/Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReciverUserID = new SelectList(db.Users, "Id", "Name", message.ReciverUserID);
            ViewBag.SenderUserID = new SelectList(db.Users, "Id", "Name", message.SenderUserID);
            return View(message);
        }

        // POST: Admin/Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,SenderUserID,ReciverUserID,Text,TimeStamp,Read")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReciverUserID = new SelectList(db.Users, "Id", "Name", message.ReciverUserID);
            ViewBag.SenderUserID = new SelectList(db.Users, "Id", "Name", message.SenderUserID);
            return View(message);
        }

        // GET: Admin/Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Admin/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
