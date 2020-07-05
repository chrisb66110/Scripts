using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ImageDtos;

namespace Catalogue2.Bll.Blls.ImageBll
{
    public interface IImageBll
    {
        Task<List<ImageDto>> GetAllAsync();
        Task<ImageDto> GetByIdAsync(long id);
        Task<ImageDto> AddAsync(ImageDto imageDto);
        Task<ImageDto> UpdateAsync(ImageDto imageDto);
        Task<ImageDto> DeleteAsync(ImageDto imageDto);
    }
}

