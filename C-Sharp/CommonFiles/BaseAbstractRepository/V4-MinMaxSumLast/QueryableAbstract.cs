using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace Prueba.Dal.Repositories
{
    public class QueryableAbstract<T, TContext> : IQueryableRepository<T> 
        where T : class
        where TContext : DbContext
    {
        private IQueryable<T> _source;

        private bool _isIIncludableQueryable;

        private TContext _context;

        private QueryableAbstract(
            IQueryable<T> source, 
            TContext context)
        {
            _source = source;
            _context = context;
            _isIIncludableQueryable = false;
        }

        public static IQueryableRepository<T> AsQueryableRepository(
            IQueryable<T> source, 
            TContext context)
        {
            return new QueryableAbstract<T, TContext>(source, context);
        }

        public IQueryable<T> AsQueryable()
        {
            return this._source;
        }

        public IQueryableRepository<T> Where(
            Expression<Func<T, bool>> predicate)
        {
            _source = Queryable.Where<T>((IQueryable<T>) _source, predicate);
            _isIIncludableQueryable = false;
            return this;
        }

        public IQueryableRepository<TResult> Select<TResult>(
            Expression<Func<T, TResult>> selector) 
            where TResult : class
        {
            var result = Queryable.Select<T, TResult>((IQueryable<T>) _source, selector);
            _isIIncludableQueryable = false;
            return new QueryableAbstract<TResult, TContext>(result, _context);
        }
        
        public IQueryableRepository<T> OrderBy<TKey>(
            Expression<Func<T, TKey>> keySelector)
        {
            _source = Queryable.OrderBy<T, TKey>((IQueryable<T>) _source, keySelector);
            _isIIncludableQueryable = false;
            return this;
        }

        public IQueryableRepository<T> OrderByDescending<TKey>(
            Expression<Func<T, TKey>> keySelector)
        {
            _source = Queryable.OrderByDescending<T, TKey>((IQueryable<T>) _source, keySelector);
            _isIIncludableQueryable = false;
            return this;
        }


        public IQueryableRepository<TResult> GroupBy<TKey, TResult>(
            Expression<Func<T, TKey>> keySelector, 
            Expression<Func<TKey, IEnumerable<T>, TResult>> resultSelector)
            where TResult : class
        {
            var result = Queryable.GroupBy<T, TKey, TResult>((IQueryable<T>) _source, keySelector, resultSelector);
            _isIIncludableQueryable = false;
            return new QueryableAbstract<TResult, TContext>(result, _context);
        }

        public IQueryableRepository<T> Distinct()
        {
            _source = Queryable.Distinct<T>((IQueryable<T>) _source);
            _isIIncludableQueryable = false;
            return this;
        }

        //.LeftJoin ----------No esta implementada realmente la funcion en EF
        //.SelectMany -------- 
        //.Select ------------ Lista
        //.Min --------------- Lista
        //.Max --------------- Lista
        //.Sum --------------- Lista
        //.Include ----------- Lista pero sin probar
        //.IncludeThen ------- Lista pero sin probar
        //.Intersect --------- Lista
        //.Join -------------- Lista
        //.Union ------------- Lista
        //.LastOrDefault ----- Lista
        //.ToDictionary ------

        public IQueryableRepository<T> Include<TProperty>
            (Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            _source = EntityFrameworkQueryableExtensions.Include(_source, navigationPropertyPath);

            return this;
        }

        public IQueryableRepository<T> Include<TPreviousProperty, TProperty>(
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
        {
            if (!_isIIncludableQueryable)
            {
                throw new Exception("You can use this method after use Include method");
            }

            var include = (IIncludableQueryable<T, TPreviousProperty>) _source;

            _source = EntityFrameworkQueryableExtensions.ThenInclude<T, TPreviousProperty, TProperty>(include, navigationPropertyPath);

            _isIIncludableQueryable = true;

            return this;
        }

        public IQueryableRepository<T> Intersect([NotNull]IQueryableRepository<T> other)
        {
            var sourceOther = ((QueryableAbstract<T, TContext>) other).AsQueryable().AsEnumerable();
            _source = Queryable.Intersect(_source, sourceOther);

            _isIIncludableQueryable = false;

            return this;
        }

        public IQueryableRepository<T> Union(IQueryableRepository<T> other)
        {
            var sourceOther = ((QueryableAbstract<T, TContext>)other).AsQueryable().AsEnumerable();
            _source = Queryable.Union(_source, sourceOther);

            _isIIncludableQueryable = false;

            return this;
        }

        public IQueryableRepository<TResult> Join<TInner, TKey, TResult>(IQueryableRepository<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector) 
            where TResult : class 
            where TInner : class
        {
            var sourceOther = ((QueryableAbstract<TInner, TContext>)inner).AsQueryable().AsEnumerable();

            var result = Queryable.Join<T, TInner, TKey, TResult>(_source, sourceOther, outerKeySelector, innerKeySelector, resultSelector);

            _isIIncludableQueryable = false;

            return new QueryableAbstract<TResult, TContext>(result, _context);
        }

        public IQueryableRepository<TOtherEntity> QueryableRepositoryOtherEntity<TOtherEntity>()
            where TOtherEntity : class
        {
            var queryable = _context.Set<TOtherEntity>().AsQueryable();
            return new QueryableAbstract<TOtherEntity, TContext>(queryable, _context);
        }
    }
}
