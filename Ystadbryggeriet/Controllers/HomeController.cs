using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ystadbryggeriet.Areas.Admin.Viewmodel;
using Ystadbryggeriet.Models;

namespace Ystadbryggeriet.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var PageViewmodel = new PageViewModel();
            PageViewmodel.happenings = db.Happenings.ToList();
            PageViewmodel.pagemodel = db.PageModels.ToList();
            return View(PageViewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}