using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsDtosNSpaceVar;
using RepositoriesNSpaceVar;

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
            var response = await _nameRepostory.AddAsync(nameModelDtoParamVar);

            return response;
        }

        public async Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var response = await _nameRepostory.UpdateAsync(nameModelDtoParamVar);

            return response;
        }

        public async Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var response = await _nameRepostory.DeleteAsync(nameModelDtoParamVar);

            return response;
        }
    }
}
