using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ProductSizeDtos;

namespace Catalogue2.Dal.Repositories.ProductSizeRepository
{
    public interface IProductSizeRepository
    {
        Task<List<ProductSizeDto>> GetAllAsync();
        Task<ProductSizeDto> GetByIdAsync(long id);
        Task<ProductSizeDto> AddAsync(ProductSizeDto productSizeDto);
        Task<ProductSizeDto> UpdateAsync(ProductSizeDto productSizeDto);
        Task<ProductSizeDto> DeleteAsync(ProductSizeDto productSizeDto);
    }
}

