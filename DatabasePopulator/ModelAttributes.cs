using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Data.Enums;

namespace DatabasePopulator
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ModelAttributes
    {
        /// <summary>
        /// The internal session id
        /// </summary>
        private int sessionId { get; set; }

        private string courseSubject { get; set; }

        private string courseNumber { get; set; }

        private string courseType { get; set; }

        private string genEd { get; set; }

        public ModelAttributes(int SessionId)
        {
            this.sessionId = SessionId;
        }

        public ModelAttributes SetDepartment(Department department)
        {
            this.courseSubject = department.ToString().ToUpperInvariant();
            return this;
        }

        public ModelAttributes SetCourseNumber(int courseNumber)
        {
            if (0 >= courseNumber || 10000 <= courseNumber)
            {
                // TODO log or throw exception?
            }

            this.courseNumber = courseNumber.ToString();
            return this;
        }

        public ModelAttributes SetIsHonors()
        {
            this.courseType = "HONORS";
            return this;
        }

        public ModelAttributes SetGenEd(GenEd genEd)
        {
            this.genEd = genEd.ToString().ToUpperInvariant().Replace("_", "-");
            return this;
        }

        public override string ToString()
        {
            return "{" +
                   "sessionId: " + sessionId + ", " +
                   (courseSubject != null && courseSubject.Any() ? "courseSubject: '" + courseSubject + "', " : "") +
                   (courseNumber != null && courseNumber.Any() ? "courseNumber: '" + courseNumber + "', " : "") +
                   (courseType != null && courseType.Any() ? "courseType: '" + courseType + "', " : "") + // IsHonors clause
                   (genEd != null && genEd.Any() ? "genEd: '" + genEd + "'" : "") +
                   "}";

        }
    }
}