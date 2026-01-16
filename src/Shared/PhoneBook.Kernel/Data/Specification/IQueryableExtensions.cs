using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace PhoneBook.Kernel.Data.Specification
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> ApplySpecification<TEntity, TSpecification>(this IQueryable<TEntity> query, Specification<TEntity, TSpecification> specification)
            where TSpecification : Specification<TEntity, TSpecification>
            where TEntity : class
        {

            if (specification != null)
            {
                if (specification.Includes != null)
                {
                    foreach (var item in specification.Includes)
                    {
                        query = query.Include(item);
                    }
                }
                
                query = query.Where(specification.ToExpression());

                specification.TotalCount = query.Count();

                if (specification.Pager != null && specification.Pager.PageSize > 0 && specification.Pager.PageNumber > 0)
                {
                    query = query.Skip((specification.Pager.PageNumber - 1) * specification.Pager.PageSize).Take(specification.Pager.PageSize);
                }

            }

            query = specification.TrackingOptions switch
            {
                enumTrackingOptions.DoNotTrack => query.AsNoTracking(),
                enumTrackingOptions.DoNotTrackWithIdentityResolution => query.AsNoTrackingWithIdentityResolution(),
                _ => query,
            };

            return query;
        }

    }
}
