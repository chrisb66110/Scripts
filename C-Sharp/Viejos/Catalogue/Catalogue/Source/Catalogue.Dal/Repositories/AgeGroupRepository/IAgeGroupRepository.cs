using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.AgeGroupDtos;

namespace Catalogue.Dal.Repositories.AgeGroupRepository
{
    public interface IAgeGroupRepository
    {
        Task<List<AgeGroupDto>> GetAllAsync();
        Task<AgeGroupDto> GetByIdAsync(string id);
        Task<AgeGroupDto> AddAsync(AgeGroupDto ageGroupDto);
        Task<AgeGroupDto> UpdateAsync(AgeGroupDto ageGroupDto);
        Task<AgeGroupDto> DeleteAsync(AgeGroupDto ageGroupDto);
    }
}

