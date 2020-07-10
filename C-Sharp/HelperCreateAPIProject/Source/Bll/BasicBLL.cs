using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using Microsoft.EntityFrameworkCore;
using ModelsDtosNSpaceVar;
using RepositoriesNSpaceVar;
using Npgsql;

namespace NameSpaceVar
{
    public class NameClassVar : NameInterfaceVar
    {
        private readonly InterfaceRepository _nameRepostory;

        public NameClassVar(InterfaceRepository nameRepostory)
        {
            _nameRepostory = nameRepostory;
        }

        public async Task<List<NameModelDtoVar>> GetAllAsync()
        {
            var response = await _nameRepostory.GetAllAsync();

            return response;
        }

        public async Task<NameModelDtoVar> GetByIdAsync(long id)
        {
            var response = await _nameRepostory.GetByIdAsync(id);

            return response;
        }

        public async Task<NameModelDtoVar> AddAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            NameModelDtoVar response;

            try
            {
                response = await _nameRepostory.AddAsync(nameModelDtoParamVar);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException inner)
            {
                if (inner.SqlState == BaseConstants.PG_DUPLICATE_ERROR)
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }
            
            return response;
        }

        public async Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            NameModelDtoVar response;

            try
            {
                response = await _nameRepostory.UpdateAsync(nameModelDtoParamVar);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (ex.Message.Contains(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY))
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }
            
            return response;
        }

        public async Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            NameModelDtoVar response;

            try
            {
                response = await _nameRepostory.DeleteAsync(nameModelDtoParamVar);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (ex.Message.Contains(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY))
                {
                    response = null;
                }
                else
                {
                    throw;
                }
            }
            
            return response;
        }
    }
}