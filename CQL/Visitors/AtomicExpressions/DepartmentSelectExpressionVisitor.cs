using System;
using System.Collections.Generic;
using System.Linq;
using CQL.Exceptions;
using CQL.Models.AtomicExpressions;
using CQL.Models.Operators;
using CQL.Visitors.Operators;
using Data.Enums;

namespace CQL.Visitors.AtomicExpressions
{
    public class DepartmentSelectExpressionVisitor : CQLBaseVisitor<DepartmentSelectExpression>
    {
        public override DepartmentSelectExpression VisitDeptEqualsExpr(CQLParser.DeptEqualsExprContext context)
        {
            try
            {
                Department department = (Department)Enum.Parse(typeof(Department), context.Department().GetText(), true);
                EquivalenceOperator op = context.equivalenceOperator().Accept(new EquivalenceOperatorVisitor());
                return new DepartmentSelectExpression(department, op);
            }
            catch (Exception e)
            {
                throw new InvalidDepartmentException();
            }
        }

        public override DepartmentSelectExpression VisitDeptListExpr(CQLParser.DeptListExprContext context)
        {
            try
            {
                List<Department> departments = context.Department().Select(terminalNode => (Department)Enum.Parse(typeof(Department), terminalNode.GetText(), true)).ToList();
                MembershipOperator membershipOperator = context.membershipOperator().Accept(new MembershipOperatorVisitor());
                return new DepartmentSelectExpression(departments, membershipOperator);
            }
            catch (Exception e)
            {
                throw new InvalidDepartmentException();
            }
        }
    }
}
