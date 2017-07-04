using System.Collections.Generic;

namespace uiowa.maui.api.dto.documentation
{
    public class Resource
    {
        public List<object> parameters { get; set; }
        public List<object> errors { get; set; }
        public List<object> notes { get; set; }
        public List<object> tags { get; set; }
        public string description { get; set; }
        public bool auth { get; set; }
        public bool deprecated { get; set; }
        public string responseClass { get; set; }
        public string responseTypeInternal { get; set; }
        public string httpMethod { get; set; }
        public List<string> produces { get; set; }
        public List<object> consumes { get; set; }
        public string path { get; set; }
        public string nickName { get; set; }
    }
}