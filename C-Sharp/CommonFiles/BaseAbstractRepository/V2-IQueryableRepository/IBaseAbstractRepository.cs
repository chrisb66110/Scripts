using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prueba.Dal.Repositories
{
    /*
     * To use this respository, you need register the generic repository in start up, you can add:
     *          builder.RegisterGeneric(typeof(BaseAbstractRepository<,,>)).As(typeof(IBaseAbstractRepository<,,>));
     *
     * To use in Bll, you need add dependency
     *          IBaseAbstractRepository<model, modelDto, yourContext> modelRepository
     */
    public interface IBaseAbstractRepository<TEntity, TDto, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        public Task<List<TDto>> GetAsync(Func<IQueryableRepository<TEntity>, IQueryableRepository<TEntity>> filterFunction = null);

        public Task<List<TResultGruoupBy>> GetAsync<TResultGruoupBy>(Func<IQueryableRepository<TEntity>, IQueryableRepository<TResultGruoupBy>> filterFunction);

        public Task<TDto> GetFirstOrDefaultAsync(Func<IQueryableRepository<TEntity>, IQueryableRepository<TEntity>> filterFunction = null);

        public Task<TDto> AddAsync(TDto dto);

        public Task<List<TDto>> AddRangeAsync(List<TDto> dtos);

        public Task<TDto> UpdateAsync(TDto dto);

        public Task<List<TDto>> UpdateRangeAsync(List<TDto> dto);

        public Task<TDto> RemoveAsync(TDto dto);

        public Task<List<TDto>> RemoveRangeAsync(List<TDto> dto);
    }
}
