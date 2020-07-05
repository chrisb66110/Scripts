using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.AgeGroupDtos;

namespace Catalogue2.Bll.Blls.AgeGroupBll
{
    public interface IAgeGroupBll
    {
        Task<List<AgeGroupDto>> GetAllAsync();
        Task<AgeGroupDto> GetByIdAsync(long id);
        Task<AgeGroupDto> AddAsync(AgeGroupDto ageGroupDto);
        Task<AgeGroupDto> UpdateAsync(AgeGroupDto ageGroupDto);
        Task<AgeGroupDto> DeleteAsync(AgeGroupDto ageGroupDto);
    }
}

