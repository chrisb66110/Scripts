using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.SizeDtos;

namespace Catalogue2.Bll.Blls.SizeBll
{
    public interface ISizeBll
    {
        Task<List<SizeDto>> GetAllAsync();
        Task<SizeDto> GetByIdAsync(long id);
        Task<SizeDto> AddAsync(SizeDto sizeDto);
        Task<SizeDto> UpdateAsync(SizeDto sizeDto);
        Task<SizeDto> DeleteAsync(SizeDto sizeDto);
    }
}

