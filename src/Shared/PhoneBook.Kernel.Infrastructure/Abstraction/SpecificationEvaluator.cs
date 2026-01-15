//using Microsoft.EntityFrameworkCore;

//namespace PhoneBook.Kernel.Infrastructure.Abstraction
//{
//    public static class SpecificationEvaluator<TEntity> where TEntity : class
//    {
//        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
//        {
//            var query = inputQuery;
//            if (spec.Criteria != null) query = query.Where(spec.Criteria);

//            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

//            if (spec.OrderBy != null) query = query.OrderBy(spec.OrderBy);

//            return query;
//        }
//    }
//}
