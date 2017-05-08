using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Interfaces;
using CQL.Models;
using CQL.Visitors.AtomicExpressions;

namespace CQL.Visitors
{
    public class AtomicExpressionVisitor : CQLBaseVisitor<IAtomicExpression>
    {
        public override IAtomicExpression VisitCourseNumberSelectExpression(CQLParser.CourseNumberSelectExpressionContext context)
        {
            return context.Accept(new CourseNumberSelectExpressionVisitor());
        }

        public override IAtomicExpression VisitDepartmentSelectExpression(CQLParser.DepartmentSelectExpressionContext context)
        {
            return context.Accept(new DepartmentSelectExpressionVisitor());
        }

        public override IAtomicExpression VisitGenEdSelectExpression(CQLParser.GenEdSelectExpressionContext context)
        {
            return context.Accept(new GenEdSelectExpressionVisitor());
        }

        public override IAtomicExpression VisitIsHonorsSelectExpression(CQLParser.IsHonorsSelectExpressionContext context)
        {
            return context.Accept(new IsHonorsSelectExpressionVisitor());
        }

        public override IAtomicExpression VisitAtomicExpression(CQLParser.AtomicExpressionContext context)
        {
            if (context.courseNumberSelectExpression() != null)
            {
                return this.VisitCourseNumberSelectExpression(context.courseNumberSelectExpression());
            }
            if (context.departmentSelectExpression() != null)
            {
                return this.VisitDepartmentSelectExpression(context.departmentSelectExpression());
            }
            if (context.genEdSelectExpression() != null)
            {
                return this.VisitGenEdSelectExpression(context.genEdSelectExpression());
            }
            if (context.isHonorsSelectExpression() != null)
            {
                return this.VisitIsHonorsSelectExpression(context.isHonorsSelectExpression());
            }
            // TODO this should be unreachable. Throw exception
            return base.VisitAtomicExpression(context);
        }
    }
}
