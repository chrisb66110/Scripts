using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ProductColorDtos;
using Catalogue2.Dal.Repositories.ProductColorRepository;

namespace Catalogue2.Bll.Blls.ProductColorBll
{
    public class ProductColorBll : IProductColorBll
    {
        private readonly IProductColorRepository _productColorRepository;

        public ProductColorBll(IProductColorRepository productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }

        public async Task<List<ProductColorDto>> GetAllAsync()
        {
            var response = await _productColorRepository.GetAllAsync();

            return response;
        }

        public async Task<ProductColorDto> GetByIdAsync(long id)
        {
            var response = await _productColorRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ProductColorDto> AddAsync(ProductColorDto productColorDto)
        {
            var response = await _productColorRepository.AddAsync(productColorDto);

            return response;
        }

        public async Task<ProductColorDto> UpdateAsync(ProductColorDto productColorDto)
        {
            var response = await _productColorRepository.UpdateAsync(productColorDto);

            return response;
        }

        public async Task<ProductColorDto> DeleteAsync(ProductColorDto productColorDto)
        {
            var response = await _productColorRepository.DeleteAsync(productColorDto);

            return response;
        }
    }
}

