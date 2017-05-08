using System.Collections.Generic;

namespace Data.Models.Session
{
    public class SessionApiResponse
    {
        public bool error { get; set; }
        public bool hasPayload { get; set; }
        public object message { get; set; }
        public IEnumerable<CourseSectionDTO> payload { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public int recordCount { get; set; }
        public List<int> cursors { get; set; }
    }
}
