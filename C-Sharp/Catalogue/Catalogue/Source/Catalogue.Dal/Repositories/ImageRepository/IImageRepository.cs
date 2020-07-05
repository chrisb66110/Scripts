using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ImageDtos;

namespace Catalogue.Dal.Repositories.ImageRepository
{
    public interface IImageRepository
    {
        Task<List<ImageDto>> GetAllAsync();
        Task<ImageDto> GetByIdAsync(long id);
        Task<ImageDto> AddAsync(ImageDto imageDto);
        Task<ImageDto> UpdateAsync(ImageDto imageDto);
        Task<ImageDto> DeleteAsync(ImageDto imageDto);
    }
}

