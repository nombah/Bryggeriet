using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ystadbryggeriet.Areas.Admin.Viewmodel;
using Ystadbryggeriet.Models;
using Microsoft.AspNet.Identity;

namespace Ystadbryggeriet.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            string user = User.Identity.GetUserId();
            var unread = db.Messages.Where(Read => Read.Read == false && Read.ReciverUserID == user).Count();
            var PageViewmodel = new PageViewModel();
            PageViewmodel.happenings = db.Happenings.ToList();
            PageViewmodel.pagemodel = db.PageModels.ToList();
            PageViewmodel.Users = db.Users.ToList();
            PageViewmodel.Unread = unread;
            if (unread > 0) 
            { 
                ViewBag.unread = unread; 
            }

            return View(PageViewmodel);
        }
        public ActionResult Gallery()
        {
            return View();
        }
        
        public ActionResult Notification(int id)
        { 
             string user = User.Identity.GetUserId();
             var unread = db.Messages.Where(Read => Read.Read == false && Read.ReciverUserID == user).Count();
             return View(unread);
        }
    }
}