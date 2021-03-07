using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification()
        {
        }
        
        protected BaseSpecification(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
        }

        public Expression<Func<T, bool>> Filter { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } =
            new List<Expression<Func<T, object>>>();

        public List<Expression<Func<T, bool>>> Filters { get; set; } =
            new List<Expression<Func<T, bool>>>();


        protected void AddInclude(List<Expression<Func<T, object>>> includes,
            Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddFilters(List<Expression<Func<T, bool>>> filters,
            Expression<Func<T, bool>> filterToAdd)
        {
            filters.Add(filterToAdd);
        }
    }
}