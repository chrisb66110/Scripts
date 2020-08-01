using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsDtosNSpaceVar;

namespace NameSpaceVar
{
    public interface NameClassVar
    {
        Task<List<NameModelDtoVar>> GetAllAsync();
        Task<NameModelDtoVar> GetByIdAsync(long id);
        Task<NameModelDtoVar> AddAsync(NameModelDtoVar nameModelDtoParamVar);
        Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar);
        Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar);
        Task<List<NameModelLogDtoVar>> GetLogsAsync();
    }
}