using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PhoneBook.Kernel.Data.Specification
{
    public abstract partial class Specification<TEntity, TSpecification> where TSpecification : Specification<TEntity, TSpecification>
    {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        public TSpecification Include(params Expression<Func<TEntity, object>>[] navigations)
        {
            if (navigations != null)
                Includes.AddRange(navigations);

            return (TSpecification)this;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            Func<TEntity, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public enumTrackingOptions TrackingOptions { get; set; } = enumTrackingOptions.Track;

        public QueryPager Pager { get; set; }

        public int TotalCount { get; internal set; }

    }


}
