using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ystadbryggeriet.Models
{
    public class events
    {
        [Key]
        public int EventId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
 
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}