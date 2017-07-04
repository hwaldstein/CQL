using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api
{
    public class ProgramOfStudy : ApiBase
    {
        /*
         * ProgramOfStudy - Operations about programs of study
             - findById - Find a specific program of study by id
             - findByCollegeNaturalKey - Find programs of study by their containing college natural keys
             - findByProgramNaturalKey - Find programs of study by their program natural keys
             - findByManagingAcademicUnitNaturalKey - Find active programs of study for a session by their managing academic unit natural keys (use academic unit service)
             - findActiveMinors - Find all active minors available
             - findSelfDeclarableCertificates - Find all active certificates that can be self-declared via ISIS
         */
    }
}
