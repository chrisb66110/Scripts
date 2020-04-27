using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Prueba.Dal.Repositories
{
    public class QueryableAbstract<T> : IQueryableRepository<T>
    {
        private IQueryable<T> _source;

        public QueryableAbstract(IQueryable<T> source)
        {
            _source = source;
        }

        public static IQueryableRepository<T> AsQueryableRepository(IQueryable<T> source)
        {
            return new QueryableAbstract<T>(source);
        }

        public IQueryable<T> AsQueryable()
        {
            return Queryable.AsQueryable(_source.AsEnumerable());
        }

        public IQueryableRepository<T> Where(Expression<Func<T, bool>> predicate)
        {
            _source = Queryable.Where<T>((IQueryable<T>) _source, predicate);
            return this;
        }

        public IQueryableRepository<T> Select(Expression<Func<T, T>> selector)
        {
            _source = Queryable.Select<T,T>((IQueryable<T>) _source, selector);
            return this;
        }
        
        public IQueryableRepository<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _source = Queryable.OrderBy<T, TKey>((IQueryable<T>) _source, keySelector);
            return this;
        }

        public IQueryableRepository<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _source = Queryable.OrderByDescending<T, TKey>((IQueryable<T>) _source, keySelector);
            return this;
        }


        public IQueryableRepository<TResult> GroupBy<TKey, TResult>(Expression<Func<T, TKey>> keySelector, Expression<Func<TKey, IEnumerable<T>, TResult>> resultSelector)
        {
            var result = Queryable.GroupBy<T, TKey, TResult>((IQueryable<T>) _source, keySelector, resultSelector);
            return new QueryableAbstract<TResult>(result);
        }

        public IQueryableRepository<T> Distinct()
        {
            _source = Queryable.Distinct<T>((IQueryable<T>) _source);
            return this;
        }
    }
}
