using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models.Session;

namespace Data.Interfaces
{
    public interface ICourseSectionDB : ISource
    {
        DbSet<CourseSection> CourseSections { get; set; }
        int SaveChanges();
    }
}
