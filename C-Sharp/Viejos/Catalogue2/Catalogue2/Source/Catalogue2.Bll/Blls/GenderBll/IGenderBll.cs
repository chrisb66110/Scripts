using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.GenderDtos;

namespace Catalogue2.Bll.Blls.GenderBll
{
    public interface IGenderBll
    {
        Task<List<GenderDto>> GetAllAsync();
        Task<GenderDto> GetByIdAsync(long id);
        Task<GenderDto> AddAsync(GenderDto genderDto);
        Task<GenderDto> UpdateAsync(GenderDto genderDto);
        Task<GenderDto> DeleteAsync(GenderDto genderDto);
    }
}

