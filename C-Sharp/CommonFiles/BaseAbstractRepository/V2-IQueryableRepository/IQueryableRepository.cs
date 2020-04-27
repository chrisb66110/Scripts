using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Prueba.Dal.Models;

namespace Prueba.Dal.Repositories
{
    public interface IQueryableRepository<T>
    {
        //IQueryableRepository<T> AsQueryableRepository(IQueryable<T> source);
        //protected IQueryable<T> AsQueryable();
        IQueryableRepository<T> Distinct();
        IQueryableRepository<TResult> GroupBy<TKey, TResult>(Expression<Func<T, TKey>> keySelector, Expression<Func<TKey, IEnumerable<T>, TResult>> resultSelector);
        IQueryableRepository<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IQueryableRepository<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        IQueryableRepository<T> Select(Expression<Func<T, T>> selector);
        IQueryableRepository<T> Where(Expression<Func<T, bool>> predicate);
    }
}
