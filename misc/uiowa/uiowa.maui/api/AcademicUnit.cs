using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using uiowa.maui.api.dto.documentation;
using uiowa.maui.api.dto.registrar.academicunits;

namespace uiowa.maui.api
{
    public class AcademicUnit : ApiBase
    {
        /*
         * AcademicUnit - Operations about Academic Units
            - findById - Find an academic unit by id
            - findByNaturalKey - Find an academic unit by natural key
            */

        /// <summary>
        /// Find all course offering academic units
        /// </summary>
        public IEnumerable<AcademicUnitDTO> FindAll()
        {
            var client = new RestClient(BaseUrl + "/pub/registrar/academicunits");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<AcademicUnitDTO>>(response.Content);
        }

        /*
        - findWorkflowOffice - Find workflow mfk by academic unit id
        - findAllColleges - Find all colleges
        - findDepartmentsByCollege - Find departments by college id
        - findDepartmentsByCollegeNaturalKey - Find departments by college natural key
        - findCourseOfferingUnitsByCollege - Find course offereing units by college id
        - findAcademicUnitNoteBySession - Find Academic Unit notes by academic unit id and session
        - findAcademicUnitNoteBySession - Find Academic Unit notes by academic unit natural key and session
     */
    }
}
