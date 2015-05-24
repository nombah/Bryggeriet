using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ystadbryggeriet.Models;

namespace Ystadbryggeriet.Areas.Admin.Viewmodel
{
    public class TestViewModel
    {
        public List<Question> questions { get; set; }
        public Test test { get; set; }
    }
}
