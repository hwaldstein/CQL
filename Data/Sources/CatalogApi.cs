using System;
using System.Linq;
using Data.Enums;
using Data.Interfaces;

namespace Data.Sources
{
    public class CatalogApi : ISource
    {
        public CatalogApi(int startYear)
        {
            
        }

        public IQueryable<ICourse> IsHonors()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> NotHonors()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> IsGenEd(GenEd genEd)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> NotGenEd(GenEd genEd)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> IsDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> NotDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> IsCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> NotCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> GreaterThanCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> GreaterThanOrEqualToCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> LessThanCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ICourse> LessThanOrEqualToCourseNumber(int courseNumber)
        {
            throw new NotImplementedException();
        }
    }
}
