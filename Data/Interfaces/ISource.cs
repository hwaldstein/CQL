using System.Data.Entity;
using System.Linq;
using Data.Enums;
using Data.Models.Session;

namespace Data.Interfaces
{
    public interface ISource
    {
        IQueryable<ICourse> IsHonors();
        IQueryable<ICourse> NotHonors();

        IQueryable<ICourse> IsGenEd(GenEd genEd);
        IQueryable<ICourse> NotGenEd(GenEd genEd);

        IQueryable<ICourse> IsDepartment(Department department);
        IQueryable<ICourse> NotDepartment(Department department);

        IQueryable<ICourse> IsCourseNumber(int courseNumber);
        IQueryable<ICourse> NotCourseNumber(int courseNumber);
        IQueryable<ICourse> GreaterThanCourseNumber(int courseNumber);
        IQueryable<ICourse> GreaterThanOrEqualToCourseNumber(int courseNumber);
        IQueryable<ICourse> LessThanCourseNumber(int courseNumber);
        IQueryable<ICourse> LessThanOrEqualToCourseNumber(int courseNumber);
    }
}
