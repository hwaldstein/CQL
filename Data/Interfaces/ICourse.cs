using System.Collections.Generic;
using Data.Enums;

namespace Data.Interfaces
{
    public interface ICourse
    {
        Department Department { get; }
        int CourseNumber { get; }

        string CourseTitle { get; }

        IEnumerable<GenEd> GenEds { get; }

        bool IsHonors { get; }
    }
}
