using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Session;
using Data.Sources;
using Newtonsoft.Json;

namespace DatabasePopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Populator> populators = new List<Populator>
            {
                new Populator(new Spring2017Context(), Spring2017Context.SessionId)
            };

            foreach (Populator populator in populators)
            {
                if (populator.Context.CourseSections.Any())
                {
                    
                }
                Console.WriteLine("================================================================================\nPopulating initial.\n================================================================================");
                populator.PopulateInitial();
                Console.WriteLine("================================================================================\nPopulating IsHonors property.\n================================================================================");
                populator.PopulateHonors();
                Console.WriteLine("================================================================================\nPopulating GenEds.\n================================================================================");
                populator.PopulateGenEds();
                
            }

            Console.Write("================================================================================\nDone. Hit enter to exit.");
            Console.ReadLine();
        }
    }
}
