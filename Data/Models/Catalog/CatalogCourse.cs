using System.Collections.Generic;
using Data.Enums;
using Data.Interfaces;

namespace Data.Models.Catalog
{
    public class CatalogCourse : ICourse
    {
        public Department Department { get; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; }
        public IEnumerable<GenEd> GenEds { get; }
        public bool IsHonors { get; }
    }
}
