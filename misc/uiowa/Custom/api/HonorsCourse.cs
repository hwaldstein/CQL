using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.api.dto;
using HtmlAgilityPack;
using RestSharp;

namespace Custom
{
    public class HonorsCourse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionId">Session code, e.g. 67. Uses current session if null.</param>
        /// <param name="courseSubject"></param>
        /// <param name="courseNumber"></param>
        /// <returns></returns>
        public IEnumerable<Course> GetHonorsCourses(int sessionId, string courseSubject = "", int courseNumber = -1)
        {
            //*[@id="content"]/div/div[3]/div/div[2]/div[1]/text()
            string requestString = "https://myui.uiowa.edu/my-ui/courses/honors.page?q.courseSubject=" + courseSubject +
                                   "&q.courseNumber=" + (courseNumber == -1 ? "" : courseNumber.ToString()) +
                                   "&q.sessionId=" + sessionId +
                                   "&q.courseType=HONORS";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(requestString);


            var resultsDescription =
                document.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div/div[3]/div/div[2]/div[1]/text()")
                    .InnerText.Split()
                    .First();
            int n;
            bool hasResults = int.TryParse(resultsDescription, out n);

            if (hasResults)
            {
                int pages = n / 100 + 1;
                List<Course> courses = new List<Course>();
                for (int i = pages - 1; i >= 0; i--)
                {
                    HtmlDocument doc = web.Load(requestString + "&page=" + i + 1);
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*[@id=\"search-result\"]/tbody/tr/td/b/a/text()"))
                    {
                        var courseString = node.InnerHtml.Split(':');
                        courses.Add(new Course()
                        {
                            Session = sessionId,
                            Subject = courseString[0],
                            Number = int.Parse(courseString[1]),
                            Section = courseString[2]
                        });
                    }
                }
                return courses;
            } 

            return null;
        }
    }
}
