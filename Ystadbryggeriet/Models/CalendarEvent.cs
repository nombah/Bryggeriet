using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ystadbryggeriet.Models
{
    public class CalendarEvent
    {
        public int CalendarEventId { get; set; }

        public string UserId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual ApplicationUser user { get; set; }

        public bool IsAllDay { get; set; }
    }
}