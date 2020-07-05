using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.SizeDtos;

namespace Catalogue.Bll.Blls.SizeBll
{
    public interface ISizeBll
    {
        Task<List<SizeDto>> GetAllAsync();
        Task<SizeDto> GetByIdAsync(string id);
        Task<SizeDto> AddAsync(SizeDto sizeDto);
        Task<SizeDto> UpdateAsync(SizeDto sizeDto);
        Task<SizeDto> DeleteAsync(SizeDto sizeDto);
    }
}

