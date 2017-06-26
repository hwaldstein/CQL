using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Data.Enums;
using Data.Interfaces;
using Data.Models.Session;
using Data.Sources;
using Newtonsoft.Json;

namespace DatabasePopulator
{
    public class Populator
    {
        public readonly ICourseSectionDB Context;
        private static string API_BASE = "https://api.maui.uiowa.edu/maui/api/pub/registrar/sections?";
        public readonly int SessionId;

        public Populator(ICourseSectionDB context, int sessionId)
        {
            this.Context = context;
            this.SessionId = sessionId;
        }

        private void DeleteAll()
        {
            foreach (CourseSection c in Context.CourseSections)
            {
                Console.WriteLine("Deleting: " + c);
                Context.CourseSections.Remove(c);
            }
        }

        public void PopulateInitial()
        {
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (CourseSectionDTO courseSectionDTO in Get(new ModelAttributes(SessionId).SetDepartment(department)))
                {
                    Console.WriteLine("Creating: " + courseSectionDTO);
                    CourseSection c = new CourseSection(courseSectionDTO);
                    Context.CourseSections.Add(c);
                    Context.SaveChanges();
                }
            }
        }

        public void PopulateHonors()
        {
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (CourseSectionDTO courseSectionDTO in Get(new ModelAttributes(SessionId).SetDepartment(department).SetIsHonors()))
                {
                    Console.WriteLine("Updating: " + courseSectionDTO);
                    var c = Context.CourseSections.First(x => x.CourseSectionId == courseSectionDTO.sectionId);
                    if (c != null)
                    {
                        c.IsHonors = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                    Context.SaveChanges();
                }
            }
        }

        public void PopulateGenEds()
        {
            foreach (Department department in (Department[])Enum.GetValues(typeof(Department)))
            {
                foreach (GenEd genEd in (GenEd[])Enum.GetValues(typeof(GenEd)))
                {
                    foreach (CourseSectionDTO courseSectionDTO in Get(
                        new ModelAttributes(SessionId).SetDepartment(department).SetGenEd(genEd)))
                    {
                        Console.WriteLine("Updating: " + genEd + ", " + courseSectionDTO);
                        CourseSection course = Context.CourseSections.First(x => x.CourseSectionId == courseSectionDTO.sectionId);
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
                        Context.SaveChanges();
                    }
                }
            }
        }

        private static IEnumerable<CourseSectionDTO> Get(ModelAttributes included)
        {
            string url = API_BASE;
            if (included != null)
            {
                url += "json=" + included + "&";
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
    }
}