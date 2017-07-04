using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api
{
    public class CourseSection : ApiBase
    {
        /*
         * CourseSection - Operations about courses/sections
             - getSections - Provide a list of values for a section number dropdown based on session, course subject, and course number
             - findById - Find a section by section internal id
             - findByQuery - The section/course search web service
             - findRelatedSections - Find related sections to a given section
             - findSimple - Find sections by session and subject
             - findSimple - Find sections by session, subject and course
             - findSimple - Find a section by session, subject, course and section
             - findSAndE - Find all Saturday and evening classes by legacy session id
             - findSimpleLegacy - Find a section by session, department, course and section all in LEGACY format
             - findByIdAndCourseIdentity - Find a single section by internal ids
             - fullTextSearch - Full Text Search. Like Google
             - findRelationships - Find all section types related to the given section by the given relationship type
             - findViableSections - Find sections that an enrollment for this section may change to
             - findEnrollmentCounts - Fetch the enrollments and status for a list of sections
             - findTimesAndLocations - Find all times and locations for the given section
             - findInstructors - Find all instructors for the given section
             - findRestrictedEnrollments - Find the enrollment information for each seat restriction on a section
         */
    }
}
