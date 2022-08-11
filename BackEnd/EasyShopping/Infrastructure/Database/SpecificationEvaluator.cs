using EasyShopping.Core.Interfaces;
using EasyShopping.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyShopping.Infrastructure.Database
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
