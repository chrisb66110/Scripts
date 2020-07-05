using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.AgeGroupDtos;
using Catalogue.Dal.Repositories.AgeGroupRepository;

namespace Catalogue.Bll.Blls.AgeGroupBll
{
    public class AgeGroupBll : IAgeGroupBll
    {
        private readonly IAgeGroupRepository _ageGroupRepository;

        public AgeGroupBll(IAgeGroupRepository ageGroupRepository)
        {
            _ageGroupRepository = ageGroupRepository;
        }

        public async Task<List<AgeGroupDto>> GetAllAsync()
        {
            var response = await _ageGroupRepository.GetAllAsync();

            return response;
        }

        public async Task<AgeGroupDto> GetByIdAsync(long id)
        {
            var response = await _ageGroupRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<AgeGroupDto> AddAsync(AgeGroupDto ageGroupDto)
        {
            var response = await _ageGroupRepository.AddAsync(ageGroupDto);

            return response;
        }

        public async Task<AgeGroupDto> UpdateAsync(AgeGroupDto ageGroupDto)
        {
            var response = await _ageGroupRepository.UpdateAsync(ageGroupDto);

            return response;
        }

        public async Task<AgeGroupDto> DeleteAsync(AgeGroupDto ageGroupDto)
        {
            var response = await _ageGroupRepository.DeleteAsync(ageGroupDto);

            return response;
        }
    }
}

