using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ystadbryggeriet.Models
{
    public class Happenings
    {
        public int HappeningsId { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}