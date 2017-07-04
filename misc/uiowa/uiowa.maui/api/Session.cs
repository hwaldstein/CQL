using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using uiowa.maui.api.dto.documentation;
using uiowa.maui.api.dto.session;

namespace uiowa.maui.api
{
    /// <summary>
    /// Session read operations
    /// </summary>
    public class Session : ApiBase
    {
        /// <summary>
        /// Find a session by it's internal id
        /// </summary>
        public void FindById()
        {
            // TODO
        }

        /// <summary>
        /// Find all sessions
        /// </summary>
        public IEnumerable<SessionDTO> FindAll()
        {
            var client = new RestClient(BaseUrl + "/pub/registrar/sessions");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<SessionDTO>>(response.Content);
        }

        /// <summary>
        /// Find the next session based on a given session's internal id
        /// </summary>
        public void FindNextSession()
        {
            // TODO
        }

        /// <summary>
        /// Find current session
        /// </summary>
        public SessionDTO FindCurrent()
        {
            var client = new RestClient(BaseUrl + "/pub/registrar/sessions/current");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<SessionDTO>(response.Content);
        }

        /// <summary>
        /// Find all sessions valid for Admissions
        /// </summary>
        public void FindAdmissionsSessions()
        {
            // TODO
        }

        /// <summary>
        /// Find the previous session based on a given session's internal id
        /// </summary>
        public void FindPreviousSession()
        {
            // TODO
        }

        /// <summary>
        /// Find a session by it's internal id
        /// </summary>
        public void FindSubSessions()
        {
            // TODO
        }

        /// <summary>
        /// Find a list of sessions going back specified number and future number
        /// </summary>
        public void FindByNumberPreviousAndFuture()
        {
            // TODO
        }

        /// <summary>
        /// Find a session by it's internal id
        /// </summary>
        public void FindSubSessionById()
        {
            // TODO
        }

        /// <summary>
        /// Find a session by it's legacy code
        /// </summary>
        public void FindbyLegacyId()
        {
            // TODO
        }

        /// <summary>
        /// Find the sessions shown on the ISIS course browse page
        /// </summary>
        public void FindCourseBrowseSessions()
        {
            // TODO
        }

        /// <summary>
        /// Find the sessions shown on the ISIS registration page
        /// </summary>
        public void FindRegisterSessions()
        {
            // TODO
        }

        /// <summary>
        /// Find the default session shown on the ISIS registration page
        /// </summary>
        public void FindRegistrationDefault()
        {
            // TODO
        }

        /// <summary>
        /// Find the default session shown on the ISIS course browse page
        /// </summary>
        public void FindBrowseDefault()
        {
            // TODO
        }

        /// <summary>
        /// Find a list of sessions specified by a query
        /// </summary>
        public void FindRange()
        {
            // TODO
        }
    }
}
