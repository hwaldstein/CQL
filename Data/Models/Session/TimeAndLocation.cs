namespace Data.Models.Session
{
    public class TimeAndLocation
    {
        public int id { get; set; }
        public int sortOrder { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string recurrence { get; set; }
        public string dates { get; set; }
        public string days { get; set; }
        public bool sun { get; set; }
        public bool mon { get; set; }
        public bool tue { get; set; }
        public bool wed { get; set; }
        public bool thu { get; set; }
        public bool fri { get; set; }
        public bool sat { get; set; }
        public string room { get; set; }
        public string building { get; set; }
        public bool arrangedLocation { get; set; }
        public bool arrangedTime { get; set; }
        public bool offsite { get; set; }
        public object offsiteBuilding { get; set; }
        public object offsiteStreet { get; set; }
        public object offsiteCity { get; set; }
        public string offsiteState { get; set; }
        public string offsiteCountry { get; set; }
        public object learningCenter { get; set; }
        public string fullRecurrence { get; set; }
    }
}
