using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api.dto.registrar.academicunits
{
    public class AcademicUnitDTO
    {
        public int id { get; set; }
        public object parentId { get; set; }
        public object programName { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string naturalKey { get; set; }
        public string url { get; set; }
        public string generalCatalogUrl { get; set; }
        public string email { get; set; }
        public string buildingShortName { get; set; }
        public string buildingName { get; set; }
        public string room { get; set; }
        public string areaCode { get; set; }
        public string phone { get; set; }
        public string faxAreaCode { get; set; }
        public string faxPhone { get; set; }
        public Person person { get; set; }
        public object collegeName { get; set; }
        public bool courseOffering { get; set; }
        public string status { get; set; }
        public UnitTypeLookup unitTypeLookup { get; set; }
        public string organization { get; set; }
        public string department { get; set; }
        public string subDepartment { get; set; }
    }
}
