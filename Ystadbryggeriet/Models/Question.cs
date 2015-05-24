using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ystadbryggeriet.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
        public string Questions { get; set; }
        public string Answer { get; set; }
    }
}
