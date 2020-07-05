using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.SizeDtos;

namespace Catalogue.Dal.Repositories.SizeRepository
{
    public interface ISizeRepository
    {
        Task<List<SizeDto>> GetAllAsync();
        Task<SizeDto> GetByIdAsync(long id);
        Task<SizeDto> AddAsync(SizeDto sizeDto);
        Task<SizeDto> UpdateAsync(SizeDto sizeDto);
        Task<SizeDto> DeleteAsync(SizeDto sizeDto);
    }
}

