using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Data.Interfaces;

namespace Data.Models.Session
{
    public class CourseSectionDTO : ICourse
    {
        public int courseId { get; set; }
        public string courseTitle { get; set; }
        public string prerequisite { get; set; }
        public bool hasAdditionalRequirements { get; set; }
        public bool isMultiSectionRegistration { get; set; }
        public int courseIdentityId { get; set; }
        public int academicUnitId { get; set; }
        public string subjectCourse { get; set; }
        public string legacyDeptCourse { get; set; }
        public long sectionId { get; set; }
        public int session { get; set; }
        public object subSession { get; set; }
        public string beginDate { get; set; }
        public string endDate { get; set; }
        public string sectionNumber { get; set; }
        public object title { get; set; }
        public object subTitle { get; set; }
        public object adminCollege { get; set; }
        public object generalCatalogUrl { get; set; }
        public object repeatability { get; set; }
        public object gradingInstructions { get; set; }
        public object corequisites { get; set; }
        public List<object> genEds { get; set; }
        public string status { get; set; }
        public string plannerStatus { get; set; }
        public string sectionType { get; set; }
        public int sectionTypeSortOrder { get; set; }
        public object waitListPlan { get; set; }
        public string managementType { get; set; }
        public object syllabusUUID { get; set; }
        public bool syllabusRequired { get; set; }
        public string hours { get; set; }
        public string minFeeHours { get; set; }
        public string maxEnroll { get; set; }
        public string maxUnreservedEnroll { get; set; }
        public int currentEnroll { get; set; }
        public int currentUnreservedEnroll { get; set; }
        public bool autoEnrolled { get; set; }
        public bool unlimitedEnroll { get; set; }
        public bool offcycle { get; set; }
        public bool isIndependentStudySection { get; set; }
        public bool adminRegistrationOnly { get; set; }
        public bool prerequisiteEnforced { get; set; }
        public object deliveryModes { get; set; }
        public object deliveryTools { get; set; }
        public List<string> globalRestrictions { get; set; }
        public List<object> seatRestrictions { get; set; }
        public List<TimeAndLocation> timeAndLocations { get; set; }
        public List<object> additionalTimes { get; set; }
        public List<object> screeningTimes { get; set; }
        public List<object> examTimes { get; set; }
        public List<Instructor> instructors { get; set; }
        public List<object> courseTypes { get; set; }
        public List<object> textBooks { get; set; }
        public object courseFees { get; set; }
        public object adminHome { get; set; }
        public object legacyAdminHome { get; set; }
        public object crossReferences { get; set; }
        public object legacyCrossReferences { get; set; }
        public object coexistingSections { get; set; }
        public object legacyCoexistingSections { get; set; }
        public object generalCatalogText { get; set; }
        public string requirements { get; set; }
        public object recommendations { get; set; }
        public object sectionInfo { get; set; }
        public string registrationInfo { get; set; }
        public List<object> mandatoryGroup { get; set; }
        public object mandatoryId { get; set; }
        public object mandatorySectionNumber { get; set; }
        public List<object> preferredGroup { get; set; }
        public List<object> preferredGroupSectionTypes { get; set; }
        public List<object> exams { get; set; }
        public object lastDayToDropOrReduceHoursWithTuitionReduction { get; set; }
        public object lastDayToAddDropNoFee { get; set; }
        public object lastDayToAddWithoutDeanApproval { get; set; }
        public object lastDayToDropWithoutW { get; set; }
        public object lastDayToDropWithoutDeanApprovalUndergrad { get; set; }
        public object lastDayToDropWithoutDeanApprovalGrad { get; set; }

        public Department Department => (Department)Enum.Parse(typeof(Department), subjectCourse.Split(':').First(), true);
        public int CourseNumber => Convert.ToInt32(this.subjectCourse.Split(':').Last());

        public string CourseTitle => courseTitle;
        public IEnumerable<GenEd> GenEds => new List<GenEd>(); // TODO the api doesn't respond with GenEds
        public bool IsHonors => false; // TODO the api doesn't respond with this

        public override int GetHashCode() => (int)sectionId;


        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            CourseSection courseSection = (CourseSection) obj;
            return this.GetHashCode() == courseSection.GetHashCode();
        }

        public override string ToString() => Department + ":" + CourseNumber + " " + CourseTitle;
    }
}
