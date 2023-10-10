using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sol.UI.Util
{
    public class CacheData
    {
        public SelectList Sections { get; set; }
        public SelectList Students { get; set; }
        public SelectList Courses { get; set; }
        public SelectList EnrollmentTypes { get; set; }
    }
}