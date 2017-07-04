using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api.dto.registrar.course
{
    public class Course
    {
        public string title { get; set; }
        public string catalogDescription { get; set; }
        public string lastTaught { get; set; }
        public int lastTaughtId { get; set; }
        public string lastTaughtCode { get; set; }
        public string courseNumber { get; set; }
        public string legacyCourseNumber { get; set; }
        public string creditHours { get; set; }
    }
}
