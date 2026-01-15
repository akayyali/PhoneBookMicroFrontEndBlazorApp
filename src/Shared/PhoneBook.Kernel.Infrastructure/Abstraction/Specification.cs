//using System.Linq.Expressions;

//namespace PhoneBook.Kernel.Infrastructure.Abstraction
//{
//    public abstract class Specification<T> : ISpecification<T>
//    {
//        public Expression<Func<T, bool>> Criteria { get; }
//        public List<Expression<Func<T, object>>> Includes { get; } = new();
//        public Expression<Func<T, object>> OrderBy { get; private set; }

//        protected Specification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

//        protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);
//        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;


//    }
//}
