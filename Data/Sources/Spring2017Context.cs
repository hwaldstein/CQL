using System;
using System.Data.Entity;
using System.Linq;
using Data.Enums;
using Data.Interfaces;
using Data.Models.Session;

namespace Data.Sources
{
    public class Spring2017Context : AbstractCourseSectionContext
    {
        public Spring2017Context() : base("name=Spring2017Context")
        {
            
        }
        public static readonly int SessionId = 67;
    }
}
