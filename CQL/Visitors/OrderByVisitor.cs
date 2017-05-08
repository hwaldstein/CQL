using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Enums;
using CQL.Models;

namespace CQL.Visitors
{
    public class OrderByVisitor : CQLBaseVisitor<OrderByType>
    {
        public override OrderByType VisitCourseNumberAsc(CQLParser.CourseNumberAscContext context)
        {
            return OrderByType.CourseNumberAsc;
        }

        public override OrderByType VisitCourseNumberDesc(CQLParser.CourseNumberDescContext context)
        {
            return OrderByType.CourseNumberDesc;
        }

        public override OrderByType VisitDeptAsc(CQLParser.DeptAscContext context)
        {
            return OrderByType.DepartmentAsc;
        }

        public override OrderByType VisitDeptDesc(CQLParser.DeptDescContext context)
        {
            return OrderByType.DepartmentDesc;
        }

        public override OrderByType VisitGenEdAsc(CQLParser.GenEdAscContext context)
        {
            return OrderByType.GenEdAsc;
        }

        public override OrderByType VisitGenEdDesc(CQLParser.GenEdDescContext context)
        {
            return OrderByType.GenEdDesc;
        }

        public override OrderByType VisitIsHonorsAsc(CQLParser.IsHonorsAscContext context)
        {
            return OrderByType.IsHonorsAsc;
        }

        public override OrderByType VisitIsHonorsDesc(CQLParser.IsHonorsDescContext context)
        {
            return OrderByType.IsHonorsDesc;
        }
    }
}
