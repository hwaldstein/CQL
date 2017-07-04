using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api.dto.session
{
    public class SessionDTO
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string shortDescription { get; set; }
        public string legacyCode { get; set; }
    }
}
