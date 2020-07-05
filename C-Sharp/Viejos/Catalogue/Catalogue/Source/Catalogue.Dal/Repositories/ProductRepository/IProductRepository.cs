using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ProductDtos;

namespace Catalogue.Dal.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(string id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task<ProductDto> UpdateAsync(ProductDto productDto);
        Task<ProductDto> DeleteAsync(ProductDto productDto);
    }
}

