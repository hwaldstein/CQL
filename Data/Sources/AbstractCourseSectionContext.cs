using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
using Data.Interfaces;
using Data.Models.Session;

namespace Data.Sources
{
    public abstract class AbstractCourseSectionContext : DbContext, ICourseSectionDB
    {
        public AbstractCourseSectionContext(string arg) : base(arg)
        {
            
        }

        public DbSet<CourseSection> CourseSections { get; set; }

        public IQueryable<ICourse> IsHonors()
        {
            return CourseSections.Where(x => x.IsHonors);
        }

        public IQueryable<ICourse> NotHonors()
        {
            return CourseSections.Where(x => x.IsHonors == false);
        }

        public IQueryable<ICourse> IsGenEd(GenEd genEd)
        {
            if (genEd == GenEd.ENGIN_CREATIVE)
            {
                return CourseSections.Where(x => x.IsEngineeringBeCreative);
            }
            if (genEd == GenEd.HP)
            {
                return CourseSections.Where(x => x.IsHistoricalPerspectives);
            }
            if (genEd == GenEd.INTERP)
            {
                return CourseSections.Where(x => x.IsInterpretationOfLiterature);
            }
            if (genEd == GenEd.INTL_GLOBAL)
            {
                return CourseSections.Where(x => x.IsInternationalAndGlobalIssues);
            }
            if (genEd == GenEd.LIT_VIS_PA)
            {
                return CourseSections.Where(x => x.IsLiteraryVisualAndPerformingArts);
            }
            if (genEd == GenEd.NS)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesWithoutLab);
            }
            if (genEd == GenEd.NS_LAB_ONLY)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesLabOnly);
            }
            if (genEd == GenEd.NS_LAB)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesWithLab);
            }
            if (genEd == GenEd.QFR)
            {
                return CourseSections.Where(x => x.IsQuantitativeOrFormalReasoning);
            }
            if (genEd == GenEd.RHET_TWO)
            {
                return CourseSections.Where(x => x.IsRhetoric);
            }
            if (genEd == GenEd.RHET_SPCH)
            {
                return CourseSections.Where(x => x.IsRhetoricSpeech);
            }
            if (genEd == GenEd.RHET_WRTNG)
            {
                return CourseSections.Where(x => x.IsRhetoricWriting);
            }
            if (genEd == GenEd.SS)
            {
                return CourseSections.Where(x => x.IsSocialSciences);
            }
            if (genEd == GenEd.VAL_SOC_DIV)
            {
                return CourseSections.Where(x => x.IsValuesSocietyAndDiversity);
            }
            if (genEd == GenEd.FL_1ST)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesFirstLevelProficiency);
            }
            if (genEd == GenEd.FL_2ND)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesSecondLevelProficiency);
            }
            if (genEd == GenEd.FL_4TH)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesFourthLevelProficiency);
            }
            // This should not be reachable
            throw new Exception("List of handles GenEds is invalid or incomplete.");
        }

        public IQueryable<ICourse> NotGenEd(GenEd genEd)
        {
            if (genEd == GenEd.ENGIN_CREATIVE)
            {
                return CourseSections.Where(x => x.IsEngineeringBeCreative == false);
            }
            if (genEd == GenEd.HP)
            {
                return CourseSections.Where(x => x.IsHistoricalPerspectives == false);
            }
            if (genEd == GenEd.INTERP)
            {
                return CourseSections.Where(x => x.IsInterpretationOfLiterature == false);
            }
            if (genEd == GenEd.INTL_GLOBAL)
            {
                return CourseSections.Where(x => x.IsInternationalAndGlobalIssues == false);
            }
            if (genEd == GenEd.LIT_VIS_PA)
            {
                return CourseSections.Where(x => x.IsLiteraryVisualAndPerformingArts == false);
            }
            if (genEd == GenEd.NS)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesWithoutLab == false);
            }
            if (genEd == GenEd.NS_LAB_ONLY)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesLabOnly == false);
            }
            if (genEd == GenEd.NS_LAB)
            {
                return CourseSections.Where(x => x.IsNaturalSciencesWithLab == false);
            }
            if (genEd == GenEd.QFR)
            {
                return CourseSections.Where(x => x.IsQuantitativeOrFormalReasoning == false);
            }
            if (genEd == GenEd.RHET_TWO)
            {
                return CourseSections.Where(x => x.IsRhetoric == false);
            }
            if (genEd == GenEd.RHET_SPCH)
            {
                return CourseSections.Where(x => x.IsRhetoricSpeech == false);
            }
            if (genEd == GenEd.RHET_WRTNG)
            {
                return CourseSections.Where(x => x.IsRhetoricWriting == false);
            }
            if (genEd == GenEd.SS)
            {
                return CourseSections.Where(x => x.IsSocialSciences == false);
            }
            if (genEd == GenEd.VAL_SOC_DIV)
            {
                return CourseSections.Where(x => x.IsValuesSocietyAndDiversity == false);
            }
            if (genEd == GenEd.FL_1ST)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesFirstLevelProficiency == false);
            }
            if (genEd == GenEd.FL_2ND)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesSecondLevelProficiency == false);
            }
            if (genEd == GenEd.FL_4TH)
            {
                return CourseSections.Where(x => x.IsWorldLanguagesFourthLevelProficiency == false);
            }
            // This should not be reachable
            throw new Exception("List of handles GenEds is invalid or incomplete.");
        }

        public IQueryable<ICourse> IsDepartment(Department department)
        {
            return CourseSections.Where(x => x.Department == department);
        }

        public IQueryable<ICourse> NotDepartment(Department department)
        {
            return CourseSections.Where(x => x.Department != department);
        }

        public IQueryable<ICourse> IsCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber == courseNumber);
        }

        public IQueryable<ICourse> NotCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber != courseNumber);
        }

        public IQueryable<ICourse> GreaterThanCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber > courseNumber);
        }

        public IQueryable<ICourse> GreaterThanOrEqualToCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber >= courseNumber);
        }

        public IQueryable<ICourse> LessThanCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber < courseNumber);
        }

        public IQueryable<ICourse> LessThanOrEqualToCourseNumber(int courseNumber)
        {
            return CourseSections.Where(x => x.CourseNumber <= courseNumber);
        }
    }
}
