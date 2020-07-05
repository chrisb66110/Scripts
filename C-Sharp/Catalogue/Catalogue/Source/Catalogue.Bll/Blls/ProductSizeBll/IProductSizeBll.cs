using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ProductSizeDtos;

namespace Catalogue.Bll.Blls.ProductSizeBll
{
    public interface IProductSizeBll
    {
        Task<List<ProductSizeDto>> GetAllAsync();
        Task<ProductSizeDto> GetByIdAsync(long id);
        Task<ProductSizeDto> AddAsync(ProductSizeDto productSizeDto);
        Task<ProductSizeDto> UpdateAsync(ProductSizeDto productSizeDto);
        Task<ProductSizeDto> DeleteAsync(ProductSizeDto productSizeDto);
    }
}

