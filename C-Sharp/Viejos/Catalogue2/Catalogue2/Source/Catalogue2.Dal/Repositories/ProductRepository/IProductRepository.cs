using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ProductDtos;

namespace Catalogue2.Dal.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(long id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task<ProductDto> UpdateAsync(ProductDto productDto);
        Task<ProductDto> DeleteAsync(ProductDto productDto);
    }
}

