using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsDtosNSpaceVar;

namespace NameSpaceVar
{
    public interface NameInterfaceVar
    {
        Task<List<NameModelDtoVar>> GetAllAsync();
        Task<NameModelDtoVar> GetByIdAsync(string id);
        Task<NameModelDtoVar> AddAsync(NameModelDtoVar nameModelDtoParamVar);
        Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar);
        Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar);
    }
}
