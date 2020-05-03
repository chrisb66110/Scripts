using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Prueba.Dal.Models;

namespace Prueba.Dal.Repositories
{
    public interface IQueryableRepository<T>
        where T : class
    {
        //IQueryableRepository<T> AsQueryableRepository(IQueryable<T> source);
        //protected IQueryable<T> AsQueryable();
        IQueryableRepository<T> Distinct();
        IQueryableRepository<TResult> GroupBy<TKey, TResult>(Expression<Func<T, TKey>> keySelector, Expression<Func<TKey, IEnumerable<T>, TResult>> resultSelector) where TResult : class;
        IQueryableRepository<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IQueryableRepository<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        IQueryableRepository<TResult> Select<TResult>(Expression<Func<T, TResult>> selector) where TResult : class;
        IQueryableRepository<T> Where(Expression<Func<T, bool>> predicate);




        public IQueryableRepository<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);

        public IQueryableRepository<T> Include<TPreviousProperty, TProperty>(Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath);

        public IQueryableRepository<T> Intersect(IQueryableRepository<T> source2);

        public IQueryableRepository<T> Union(IQueryableRepository<T> source2);

        public IQueryableRepository<TResult> Join<TInner, TKey, TResult>(IQueryableRepository<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector) where TResult : class where TInner : class;

        IQueryableRepository<TOtherEntity> QueryableRepositoryOtherEntity<TOtherEntity>() where TOtherEntity : class;
    }
}
