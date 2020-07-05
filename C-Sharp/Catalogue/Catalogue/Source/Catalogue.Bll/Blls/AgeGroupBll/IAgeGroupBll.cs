using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.AgeGroupDtos;

namespace Catalogue.Bll.Blls.AgeGroupBll
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

