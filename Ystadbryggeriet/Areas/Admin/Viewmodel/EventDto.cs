using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ystadbryggeriet.Areas.Admin.Viewmodel
{
    public class EventDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool allDay { get; set; }
    }
}