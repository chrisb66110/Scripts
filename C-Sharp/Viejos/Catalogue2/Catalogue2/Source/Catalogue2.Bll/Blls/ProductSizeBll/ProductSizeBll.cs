using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ProductSizeDtos;
using Catalogue2.Dal.Repositories.ProductSizeRepository;

namespace Catalogue2.Bll.Blls.ProductSizeBll
{
    public class ProductSizeBll : IProductSizeBll
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeBll(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        public async Task<List<ProductSizeDto>> GetAllAsync()
        {
            var response = await _productSizeRepository.GetAllAsync();

            return response;
        }

        public async Task<ProductSizeDto> GetByIdAsync(long id)
        {
            var response = await _productSizeRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ProductSizeDto> AddAsync(ProductSizeDto productSizeDto)
        {
            var response = await _productSizeRepository.AddAsync(productSizeDto);

            return response;
        }

        public async Task<ProductSizeDto> UpdateAsync(ProductSizeDto productSizeDto)
        {
            var response = await _productSizeRepository.UpdateAsync(productSizeDto);

            return response;
        }

        public async Task<ProductSizeDto> DeleteAsync(ProductSizeDto productSizeDto)
        {
            var response = await _productSizeRepository.DeleteAsync(productSizeDto);

            return response;
        }
    }
}

