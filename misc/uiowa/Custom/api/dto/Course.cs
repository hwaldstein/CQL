using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.api.dto
{
    public class Course
    {
        public int Session { get; set; }

        public string Subject { get; set; }

        public int Number { get; set; }

        public string Section { get; set; }
    }
}
