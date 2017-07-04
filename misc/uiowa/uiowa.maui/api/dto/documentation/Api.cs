using System.Collections.Generic;

namespace uiowa.maui.api.dto.documentation
{
    public class Api
    {
        public string name { get; set; }
        public string description { get; set; }
        public string resourcePath { get; set; }
        public List<object> consumes { get; set; }
        public List<object> produces { get; set; }
        public List<Resource> resources { get; set; }
        public List<object> subApis { get; set; }
        public string apiVersion { get; set; }
        public bool deprecated { get; set; }
    }
}