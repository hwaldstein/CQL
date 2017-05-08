using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Data.Enums;
using Data.Interfaces;
using Data.Models.Session;
using Newtonsoft.Json;

namespace Data.Sources
{
    public class SessionApi : ISource
    {
        private string API_BASE = "https://api.maui.uiowa.edu/maui/api/pub/registrar/sections?";
        private int sessionId;
        public SessionApi(Season season, int year)
        {
            sessionId = 67;
        }

        private IEnumerable<ICourse> Get(ModelAttributes included, ModelAttributes excluded)
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

        public IQueryable<ICourse> IsHonors()
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            //foreach (Department department in Enum.GetValues(typeof(Department)))
            //{
            //    IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department), null);
            //    courseSections = courseSections.Concat(c);
            //}
            //return courseSections;

            return (from Department department in Enum.GetValues(typeof(Department)) select Get(new ModelAttributes(this.sessionId).SetDepartment(department), null)).Aggregate<IEnumerable<ICourse>, IEnumerable<ICourse>>(courseSections, (current, c) => current.Concat(c)) as IQueryable<ICourse>;

        }

        public IQueryable<ICourse> NotHonors()
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department),
                                             // excluded
                                             new ModelAttributes(this.sessionId, true).SetIsHonors());
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> IsGenEd(GenEd genEd)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department).SetGenEd(genEd), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> NotGenEd(GenEd genEd)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department), 
                                             // excluded
                                             new ModelAttributes(this.sessionId, true).SetGenEd(genEd));
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> IsDepartment(Department department)
        {
            IQueryable<ICourse> output = Get(new ModelAttributes(this.sessionId).SetDepartment(department), null) as IQueryable<ICourse>;
            return output;

        }

        public IQueryable<ICourse> NotDepartment(Department department)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                if (dept == department)
                {
                    continue;
                }
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(dept), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> IsCourseNumber(int courseNumber)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department).SetCourseNumber(courseNumber), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> NotCourseNumber(int courseNumber)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(department),
                    // excluded
                    new ModelAttributes(this.sessionId, true).SetCourseNumber(courseNumber));
                courseSections = courseSections.Concat(c);
            }
            return courseSections as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> GreaterThanCourseNumber(int courseNumber)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(dept), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections.Where(x => x.CourseNumber > courseNumber) as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> GreaterThanOrEqualToCourseNumber(int courseNumber)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(dept), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections.Where(x => x.CourseNumber >= courseNumber) as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> LessThanCourseNumber(int courseNumber)
        {
            IEnumerable< ICourse > courseSections = new List<ICourse>();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(dept), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections.Where(x => x.CourseNumber < courseNumber) as IQueryable<ICourse>;
        }

        public IQueryable<ICourse> LessThanOrEqualToCourseNumber(int courseNumber)
        {
            IEnumerable<ICourse> courseSections = new List<ICourse>();
            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                IEnumerable<ICourse> c = Get(new ModelAttributes(this.sessionId).SetDepartment(dept), null);
                courseSections = courseSections.Concat(c);
            }
            return courseSections.Where(x => x.CourseNumber <= courseNumber) as IQueryable<ICourse>;
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
                       (courseType!= null && courseType.Any() ? "courseType: '" + courseType + "', " : "") + // IsHonors clause
                       (genEd != null && genEd.Any() ? "genEd: '" + genEd + "'" : "") +
                       "}";

            }
        }
    }
}
