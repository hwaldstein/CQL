using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
using Data.Models.Session;
using Data.Sources;
using Newtonsoft.Json;

namespace DatabasePopulator
{
    class Program
    {
        private static readonly Fall2017Context _context = new Fall2017Context();
        private static string API_BASE = "https://api.maui.uiowa.edu/maui/api/pub/registrar/sections?";
        private static int sessionId = 67;

        static void Main(string[] args)
        {
            //if (_context.CourseSections.Any())
            //{
            //    throw new Exception("Database table should be empty before population.");
            //}
            //Console.WriteLine("================================================================================\nPopulating initial.\n================================================================================");
            //PopulateInitial();
            Console.WriteLine("================================================================================\nPopulating IsHonors property.\n================================================================================");
            PopulateHonors();
            Console.WriteLine("================================================================================\nPopulating GenEds.\n================================================================================");
            PopulateGenEds();
            Console.Write("================================================================================\nDone. Hit enter to exit.");
            Console.ReadLine();
        }

        private static void DeleteAll()
        {
            foreach (CourseSection c in _context.CourseSections)
            {
                Console.WriteLine("Deleting: " + c);
                _context.CourseSections.Remove(c);
            }
        }

        private static void PopulateInitial()
        {
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT CourseSections ON");
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (CourseSectionDTO courseSectionDTO in Get(new ModelAttributes(sessionId).SetDepartment(department), null))
                {
                    Console.WriteLine("Creating: " + courseSectionDTO);
                    CourseSection c = new CourseSection(courseSectionDTO);
                    _context.CourseSections.Add(c);
                    _context.SaveChanges();
                }
            }
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT CourseSections OFF");
        }

        private static void PopulateHonors()
        {
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (CourseSectionDTO courseSectionDTO in Get(new ModelAttributes(sessionId).SetDepartment(department).SetIsHonors(), null))
                {
                    Console.WriteLine("Updating: " + courseSectionDTO);
                    var c = _context.CourseSections.First(x => x.CourseSectionId == courseSectionDTO.sectionId);
                    if (c != null)
                    {
                        c.IsHonors = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                    _context.SaveChanges();
                }
            }
        }

        private static void PopulateGenEds()
        {
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (GenEd genEd in (GenEd[])Enum.GetValues(typeof(GenEd)))
                {
                    foreach (CourseSectionDTO courseSectionDTO in Get(
                        new ModelAttributes(sessionId).SetDepartment(department).SetGenEd(genEd), null))
                    {
                        Console.WriteLine("Updating: " + genEd + ", " + courseSectionDTO);
                        CourseSection course = _context.CourseSections.First(x => x.CourseSectionId == courseSectionDTO.sectionId);
                        if (genEd == GenEd.ENGIN_CREATIVE)
                        {
                            course.IsEngineeringBeCreative = true;
                        }
                        if (genEd == GenEd.HP)
                        {
                            course.IsHistoricalPerspectives = true;
                        }
                        if (genEd == GenEd.INTERP)
                        {
                            course.IsInterpretationOfLiterature = true;
                        }
                        if (genEd == GenEd.INTL_GLOBAL)
                        {
                            course.IsInternationalAndGlobalIssues = true;
                        }
                        if (genEd == GenEd.LIT_VIS_PA)
                        {
                            course.IsLiteraryVisualAndPerformingArts = true;
                        }
                        if (genEd == GenEd.NS)
                        {
                            course.IsNaturalSciencesWithoutLab = true;
                        }
                        if (genEd == GenEd.NS_LAB_ONLY)
                        {
                            course.IsNaturalSciencesLabOnly = true;
                        }
                        if (genEd == GenEd.NS_LAB)
                        {
                            course.IsNaturalSciencesWithLab = true;
                        }
                        if (genEd == GenEd.QFR)
                        {
                            course.IsQuantitativeOrFormalReasoning = true;
                        }
                        if (genEd == GenEd.RHET_TWO)
                        {
                            course.IsRhetoric = true;
                        }
                        if (genEd == GenEd.RHET_SPCH)
                        {
                            course.IsRhetoricSpeech = true;
                        }
                        if (genEd == GenEd.RHET_WRTNG)
                        {
                            course.IsRhetoricWriting = true;
                        }
                        if (genEd == GenEd.SS)
                        {
                            course.IsSocialSciences = true;
                        }
                        if (genEd == GenEd.VAL_SOC_DIV)
                        {
                            course.IsValuesSocietyAndDiversity = true;
                        }
                        if (genEd == GenEd.FL_1ST)
                        {
                            course.IsWorldLanguagesFirstLevelProficiency = true;
                        }
                        if (genEd == GenEd.FL_2ND)
                        {
                            course.IsWorldLanguagesSecondLevelProficiency = true;
                        }
                        if (genEd == GenEd.FL_4TH)
                        {
                            course.IsWorldLanguagesFourthLevelProficiency = true;
                        }
                        _context.SaveChanges();
                    }
                }
            }
        }

        private static IEnumerable<CourseSectionDTO> Get(ModelAttributes included, ModelAttributes excluded)
        {
            string url = API_BASE;
            if (included != null)
            {
                url += "json=" + included + "&";
            }
            if (excluded != null)
            {
                url += "excluded=" + excluded + "&";
            }
            url += "pageStart=0&pageSize=9999&";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    SessionApiResponse resp = JsonConvert.DeserializeObject<SessionApiResponse>(reader.ReadToEnd());
                    return resp.payload;
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                    // TODO log errorText
                }
                throw;
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private class ModelAttributes
        {
            /// <summary>
            /// The internal session id
            /// </summary>
            private int sessionId { get; set; }

            private string courseSubject { get; set; }

            private string courseNumber { get; set; }

            private string courseType { get; set; }

            private string genEd { get; set; }

            private bool excluded { get; set; }

            public ModelAttributes(int SessionId)
            {
                this.sessionId = SessionId;
                this.excluded = false;
            }

            public ModelAttributes(int SessionId, bool isExcluded)
            {
                this.sessionId = SessionId;
                this.excluded = isExcluded;
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
                       (!excluded ? "sessionId: " + sessionId + ", " : "") +
                       (courseSubject != null && courseSubject.Any() ? "courseSubject: '" + courseSubject + "', " : "") +
                       (courseNumber != null && courseNumber.Any() ? "courseNumber: '" + courseNumber + "', " : "") +
                       (courseType != null && courseType.Any() ? "courseType: '" + courseType + "', " : "") + // IsHonors clause
                       (genEd != null && genEd.Any() ? "genEd: '" + genEd + "'" : "") +
                       "}";

            }
        }
    }
}
