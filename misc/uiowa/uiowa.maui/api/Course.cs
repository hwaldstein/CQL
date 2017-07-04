using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using uiowa.maui.api.dto.documentation;

namespace uiowa.maui.api
{
    /// <summary>
    /// Operations about courses
    /// </summary>
    public class Course : ApiBase
    {
        /// <summary>
        /// Provide a list of values for a course number dropdown based on session and course subject
        /// </summary>
        /// <param name="session">Five digit session legacy code</param>
        public void GetCourses(object session, object subject)
        {
            // TODO
        }

        /// <summary>
        /// Find a course by course identifier
        /// </summary>
        /// <param name="courseIdentifier">The identifier for the course. Can use new (CHEM:1110) or old (004:011) numbers</param>
        public dto.registrar.course.Course GetCourse(string courseIdentifier)
        {
            var client = new RestClient(BaseUrl + "/pub/registrar/course/" + courseIdentifier);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<dto.registrar.course.Course>(response.Content);
        }
    }
}
