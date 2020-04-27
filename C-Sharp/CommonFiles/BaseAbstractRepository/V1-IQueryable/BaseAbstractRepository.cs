using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Dal.Repositories
{
    public class BaseAbstractRepository<TEntity, TDto, TContext> : IBaseAbstractRepository<TEntity, TDto, TContext>, IDisposable
        where TEntity : class
        where TContext : DbContext
    {
        private readonly DbContextOptions<TContext> _options;
        private readonly IMapper _mapper;
        
        public BaseAbstractRepository(
            DbContextOptions<TContext> options, 
            IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /*
        public async Task<List<TDto>> GetAsync()
        {
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().AsNoTracking();

            var entities = await queryable.ToListAsync();

            var response = _mapper.Map<List<TEntity>, List<TDto>>(entities);

            return response;
        }

        public async Task<List<TDto>> GetAsync(
            Expression<Func<TEntity, bool>> whereExpression)
        {
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().Where(whereExpression).AsNoTracking();

            var entities = await queryable.ToListAsync();

            var response = _mapper.Map<List<TEntity>, List<TDto>>(entities);

            return response;
        }

        public async Task<List<TDto>> GetAsync<TOrder>(
            Expression<Func<TEntity, TOrder>> orderByExpression)
        {
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().OrderBy(orderByExpression).AsNoTracking();

            var entities = await queryable.ToListAsync();

            var response = _mapper.Map<List<TEntity>, List<TDto>>(entities);

            return response;
        }

        public async Task<List<TDto>> GetAsync<TOrder>(
            Expression<Func<TEntity, bool>> whereExpression,
            Expression<Func<TEntity, TOrder>> orderByExpression,
            bool isAscending)
        {
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().Where(whereExpression);

            if (isAscending)
            {
                queryable = queryable.OrderBy(orderByExpression).AsNoTracking();
            }
            else
            {
                queryable = queryable.OrderByDescending(orderByExpression).AsNoTracking();
            }

            var entities = await queryable.ToListAsync();

            var response = _mapper.Map<List<TEntity>, List<TDto>>(entities);

            return response;
        }

        public async Task<TDto> GetFirstAsync(
            Expression<Func<TEntity, bool>> whereExpression)
        {
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var x = context.Set<TEntity>();
            var queryable = context.Set<TEntity>().Where(whereExpression);

            var entities = await queryable.FirstAsync();

            var response = _mapper.Map<TEntity, TDto>(entities);

            return response;
        }*/





        //private IQueryable<TEntity> DefaultFilterFunction(IQueryable<TEntity> queryable)
        //{
        //    //var a = x.AsQueryable();
        //    //var t = x.Distinct().AsQueryable();
        //    //var b = x.GroupBy(x => x.Id).AsQueryable();
        //    //var c = a = x.OrderBy(x => x.Id).AsQueryable();
        //    //var d = x.OrderByDescending(x => x.Id).AsQueryable();
        //    //var h = x.Select(x => new Admin { Id = x.Id, Property = x.Property }).AsQueryable();
        //    //var j = x.Where(x => x.Id == "").AsQueryable();

        //    return queryable.AsQueryable();
        //}

        /*
         * Return the same queryable, for call when don't use filter
         */
        private IQueryable<TEntity> DefaultFilterFunction(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        /*
         * Get with optional filters
         */
        public async Task<List<TDto>> GetAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> filterFunction = null)
        {
            if (filterFunction == null)
            {
                filterFunction = DefaultFilterFunction;
            }

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().AsQueryable();

            queryable = filterFunction(queryable);

            var entities = await queryable.AsNoTracking().ToListAsync();

            var response = _mapper.Map<List<TEntity>, List<TDto>>(entities);

            await context.DisposeAsync();

            return response;
        }

        /*
         * Get with optional filters and use Group by
         */
        public async Task<List<TResultGruoupBy>> GetAsync<TResultGruoupBy>(
            Func<IQueryable<TEntity>, IQueryable<TResultGruoupBy>> filterFunction)
        {

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().AsQueryable();

            var groupQueryable = filterFunction(queryable);

            var results = await groupQueryable.ToListAsync();

            await context.DisposeAsync();

            return results;
        }

        /*
         * Get first or default with optional filter
         */
        public async Task<TDto> GetFirstOrDefaultAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> filterFunction = null)
        {
            if (filterFunction == null)
            {
                filterFunction = DefaultFilterFunction;
            }

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().AsQueryable();

            queryable = filterFunction(queryable);

            var entity = await queryable.AsNoTracking().FirstOrDefaultAsync();

            var response = _mapper.Map<TEntity, TDto>(entity);

            await context.DisposeAsync();

            return response;
        }

        /*
         * Get first or default with optional filter and remove entity returned
         */
        public async Task<TDto> GetFirstOrDefaultAndRemoveAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> filterFunction = null)
        {
            if (filterFunction == null)
            {
                filterFunction = DefaultFilterFunction;
            }

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            var queryable = context.Set<TEntity>().AsQueryable();

            queryable = filterFunction(queryable);

            var entity = await queryable.AsNoTracking().FirstOrDefaultAsync();

            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }

            var response = _mapper.Map<TEntity, TDto>(entity);

            await context.DisposeAsync();

            return response;
        }

        /*
         * Add entity
         */
        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            await context.Set<TEntity>().AddAsync(entity);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dto;
        }

        /*
         * Add entities
         */
        public async Task<List<TDto>> AddRangeAsync(List<TDto> dtos)
        {
            var entities = _mapper.Map<List<TDto>, List<TEntity>>(dtos);

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            await context.Set<TEntity>().AddRangeAsync(entities);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dtos;
        }

        /*
         * Update entity
         * Need the Id in Dto to update info
         * Don't change Id
         */
        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);
            
            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            context.Set<TEntity>().Update(entity);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dto;
        }

        /*
         * Update entities
         * Need the Id in Dtos to update info
         * Don't change Id
         */
        public async Task<List<TDto>> UpdateRangeAsync(List<TDto> dto)
        {
            var entities = _mapper.Map<List<TDto>, List<TEntity>>(dto);

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            context.Set<TEntity>().UpdateRange(entities);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dto;
        }

        /*
         * Delete entity
         * Need the Id in Dto to remove entity
         */
        public async Task<TDto> RemoveAsync(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            context.Set<TEntity>().Remove(entity);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dto;
        }

        /*
         * Delete entities
         * Need the Id in Dtos to remove entity
         */
        public async Task<List<TDto>> RemoveRangeAsync(List<TDto> dto)
        {
            var entities = _mapper.Map<List<TDto>, List<TEntity>>(dto);

            var context = (TContext)Activator.CreateInstance(typeof(TContext), _options);

            context.Set<TEntity>().RemoveRange(entities);

            await context.SaveChangesAsync();

            await context.DisposeAsync();

            return dto;
        }

        public void Dispose()
        {
        }
    }
}
