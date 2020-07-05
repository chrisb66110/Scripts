using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ProductColorDtos;

namespace Catalogue.Dal.Repositories.ProductColorRepository
{
    public interface IProductColorRepository
    {
        Task<List<ProductColorDto>> GetAllAsync();
        Task<ProductColorDto> GetByIdAsync(long id);
        Task<ProductColorDto> AddAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> UpdateAsync(ProductColorDto productColorDto);
        Task<ProductColorDto> DeleteAsync(ProductColorDto productColorDto);
    }
}

