using System;
using System.IO;
using System.Linq;
using Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScraperETL
{
    /// <summary>
    ///     Code for taking a flat-file version of the registrar's course catalog and importing it
    ///     into the database
    /// </summary>
    public static class ETL
    {
        private static readonly CourseSchedulerEntities Entities = new CourseSchedulerEntities();

        private static void Main(string[] args)
        {
            string directory = "C:/Users/harle/Desktop/Courses";
            performJsonETL(directory);
        }

        /// <summary>
        /// </summary>
        /// <param name="directory">A <see cref="Directory" /> that contains json files</param>
        private static void performJsonETL(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new ArgumentException("The given argument is not a directory.", nameof(directory));
            }

            Console.Out.WriteLine("Reading from directory: " + directory);

            var files = Directory.GetFiles(directory);

            foreach (string file in files)
            {
                using (JsonTextReader reader = new JsonTextReader(File.OpenText(file)))
                {
                    var courses = JToken.ReadFrom(reader).Last.First.Children();

                    foreach (JToken course in courses)
                    {
                        string subject = (string)course["Subject"];
                        int number = (int)course["Number"];
                        string name = (string)course["Name"];
                        string description = (string)course["Description"];
                        string hours = (string)course["Hours"];
                        string offered = (string)course["Offered"];
                        string prerequisites = (string)course["Prerequisites"];
                        string corequisites = (string)course["Corequisites"];
                        string requirements = (string)course["Requirements"];
                        string recommendations = (string)course["Recommendations"];
                        string ge = (string)course["GE"];
                        string sameas = (string)course["SameAs"];

                        RawCatalog1718 c = new RawCatalog1718
                        {
                            Subject = subject,
                            Number = number,
                            Name = name,
                            Description = description,
                            Hours = hours,
                            Offered = offered,
                            Prerequisites = prerequisites,
                            Corequisites = corequisites,
                            Requirements = requirements,
                            Recommendations = recommendations,
                            GE = ge,
                            SameAs = sameas
                        };

                        Console.Out.WriteLine("Processed couse: " + c.Subject + ":" + c.Number + " " + c.Name);

                        Entities.RawCatalog1718.Add(c);
                        Entities.SaveChanges();
                    }
                }
            }
        }
    }
}