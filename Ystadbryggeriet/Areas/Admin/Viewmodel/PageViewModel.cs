using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ystadbryggeriet.Models;

namespace Ystadbryggeriet.Areas.Admin.Viewmodel
{
    public class PageViewModel
    {
        public List<PageModel> pagemodel { get; set; }
        public List<Happenings> happenings { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public int Unread { get; set; }
    }
}