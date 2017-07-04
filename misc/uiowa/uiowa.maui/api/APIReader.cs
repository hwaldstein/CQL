using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using uiowa.maui.api.dto.documentation;

namespace uiowa.maui.api
{
    /// <summary>
    /// Services for providing api documentation
    /// </summary>
    public class APIReader : ApiBase
    {
        /// <summary>
        /// Gets all the API documentation for MAUI web services
        /// </summary>
        public Documentation GetAllDocumentation()
        {
            var client = new RestClient(BaseUrl + "/pub/documentation/all");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Documentation>(response.Content);
        }

        /// <summary>
        /// Gets the API documentation for a provided resource
        /// </summary>
        /// <param name="api">The resource path of the api you want</param>
        public Api GetApiForApiPath(string api)
        {
            var client = new RestClient(BaseUrl + "/pub/documentation/api?api=" + api.Replace("/", "%2F"));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Api>(response.Content);
        }

        /// <summary>
        /// Gets the API documentation for a provided operation
        /// </summary>
        /// <param name="resource">The resource path of the api you want</param>
        public Resource GetApiForOperationPath(string resource)
        {
            var client = new RestClient(BaseUrl + "/pub/documentation/resource?resource=" + resource.Replace("/", "%2F"));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Resource>(response.Content);
        }
    }
}
