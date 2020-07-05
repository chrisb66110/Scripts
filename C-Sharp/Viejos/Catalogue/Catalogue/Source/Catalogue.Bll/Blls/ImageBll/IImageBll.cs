using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ImageDtos;

namespace Catalogue.Bll.Blls.ImageBll
{
    public interface IImageBll
    {
        Task<List<ImageDto>> GetAllAsync();
        Task<ImageDto> GetByIdAsync(string id);
        Task<ImageDto> AddAsync(ImageDto imageDto);
        Task<ImageDto> UpdateAsync(ImageDto imageDto);
        Task<ImageDto> DeleteAsync(ImageDto imageDto);
    }
}

