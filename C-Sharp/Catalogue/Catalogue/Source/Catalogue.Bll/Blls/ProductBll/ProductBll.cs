using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Dal.Repositories.ProductRepository;

namespace Catalogue.Bll.Blls.ProductBll
{
    public class ProductBll : IProductBll
    {
        private readonly IProductRepository _productRepository;

        public ProductBll(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var response = await _productRepository.GetAllAsync();

            return response;
        }

        public async Task<ProductDto> GetByIdAsync(long id)
        {
            var response = await _productRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var response = await _productRepository.AddAsync(productDto);

            return response;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var response = await _productRepository.UpdateAsync(productDto);

            return response;
        }

        public async Task<ProductDto> DeleteAsync(ProductDto productDto)
        {
            var response = await _productRepository.DeleteAsync(productDto);

            return response;
        }
    }
}

