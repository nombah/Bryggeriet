using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ystadbryggeriet.Models
{
    public class PageModel
    {
        [Key]
        public int PageId { get; set; }
        [AllowHtml]
        public string Title { get; set; }
        [AllowHtml]
        public string PageText { get; set; }

    }
}