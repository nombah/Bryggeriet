using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ystadbryggeriet.Models
{
    public class Test
    {
        public int TestID { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public virtual List<Question> Question { get; set; }
    }

}