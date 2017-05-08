using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Data.Enums;
using Data.Interfaces;

namespace Data.Models.Session
{
    public class CourseSection : ICourse
    {
        [Obsolete("Only needed for serialization and materialization", true)]
        public CourseSection()
        {
            
        }

        public CourseSection(CourseSectionDTO dto)
        {
            this.CourseSectionId = dto.sectionId;
            this.Department = (Department)Enum.Parse(typeof(Department), dto.subjectCourse.Split(':').First(), true);
            this.CourseNumber = Convert.ToInt32(dto.subjectCourse.Split(':').Last());
            this.CourseTitle = dto.courseTitle;
            // GenEds and IsHonors not passed by the api
        }

        [Key]
        public long Key { get; set; }

        public long CourseSectionId { get; set;  }

        public Department Department { get; set; }

        public int CourseNumber { get; set; }

        public string CourseTitle { get; set; }

        public IEnumerable<GenEd> GenEds
        {
            get
            {
                List<GenEd> genEds = new List<GenEd>();
                if (IsEngineeringBeCreative)
                {
                    genEds.Add(GenEd.ENGIN_CREATIVE);
                }
                if (IsHistoricalPerspectives)
                {
                    genEds.Add(GenEd.HP);
                }
                if (IsInterpretationOfLiterature)
                {
                    genEds.Add(GenEd.INTERP);
                }
                if (IsInternationalAndGlobalIssues)
                {
                    genEds.Add(GenEd.INTL_GLOBAL);
                }
                if (IsLiteraryVisualAndPerformingArts)
                {
                    genEds.Add(GenEd.LIT_VIS_PA);
                }
                if (IsNaturalSciencesWithoutLab)
                {
                    genEds.Add(GenEd.NS);
                }
                if (IsNaturalSciencesLabOnly)
                {
                    genEds.Add(GenEd.NS_LAB_ONLY);
                }
                if (IsNaturalSciencesWithLab)
                {
                    genEds.Add(GenEd.NS_LAB);
                }
                if (IsQuantitativeOrFormalReasoning)
                {
                    genEds.Add(GenEd.QFR);
                }
                if (IsRhetoric)
                {
                    genEds.Add(GenEd.RHET_TWO);
                }
                if (IsRhetoricSpeech)
                {
                    genEds.Add(GenEd.RHET_SPCH);
                }
                if (IsRhetoricWriting)
                {
                    genEds.Add(GenEd.RHET_WRTNG);
                }
                if (IsSocialSciences)
                {
                    genEds.Add(GenEd.SS);
                }
                if (IsValuesSocietyAndDiversity)
                {
                    genEds.Add(GenEd.VAL_SOC_DIV);
                }
                if (IsWorldLanguagesFirstLevelProficiency)
                {
                    genEds.Add(GenEd.FL_1ST);
                }
                if (IsWorldLanguagesSecondLevelProficiency)
                {
                    genEds.Add(GenEd.FL_2ND);
                }
                if (IsWorldLanguagesFourthLevelProficiency)
                {
                    genEds.Add(GenEd.FL_4TH);
                }
                return genEds;
            }
        }

        public bool IsEngineeringBeCreative { get; set; }

        public bool IsHistoricalPerspectives { get; set; }

        public bool IsInternationalAndGlobalIssues { get; set; }

        public bool IsInterpretationOfLiterature { get; set; }

        public bool IsLiteraryVisualAndPerformingArts { get; set; }

        public bool IsNaturalSciencesLabOnly { get; set; }

        public bool IsNaturalSciencesWithLab { get; set; }

        public bool IsNaturalSciencesWithoutLab { get; set; }

        public bool IsQuantitativeOrFormalReasoning { get; set; }

        public bool IsRhetoric { get; set; }

        public bool IsRhetoricSpeech { get; set; }

        public bool IsRhetoricWriting { get; set; }

        public bool IsSocialSciences { get; set; }

        public bool IsValuesSocietyAndDiversity { get; set; }

        public bool IsWorldLanguagesFirstLevelProficiency { get; set; }

        public bool IsWorldLanguagesSecondLevelProficiency { get; set; }

        public bool IsWorldLanguagesFourthLevelProficiency { get; set; }

        public bool IsHonors { get; set; }

        public override int GetHashCode() => (int) CourseSectionId;

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
