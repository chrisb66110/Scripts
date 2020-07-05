using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.ProductSizeDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.ProductSizeRepository
{
    public class ProductSizeRepository : BaseRepository<ProductSize, string>, IProductSizeRepository
    {
        private readonly IMapper _mapper;

        public ProductSizeRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductSizeDto>> GetAllAsync()
        {
            var listProductSize = await _GetAllAsync();
            
            var response = _mapper.Map<List<ProductSize>, List<ProductSizeDto>>(listProductSize);
            return response;
        }

        public async Task<ProductSizeDto> GetByIdAsync(string id)
        {
            var productSize = await _GetByIdAsync(id);

            var response = _mapper.Map<ProductSize, ProductSizeDto>(productSize);
            return response;
        }

        public async Task<ProductSizeDto> AddAsync(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSizeDto, ProductSize>(productSizeDto);

            var result = await _AddAsync(productSize);

            var response = _mapper.Map<ProductSize, ProductSizeDto>(result);
            return response;
        }

        public async Task<ProductSizeDto> UpdateAsync(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSizeDto, ProductSize>(productSizeDto);

            var result = await _UpdateAsync(productSize);

            var response = _mapper.Map<ProductSize, ProductSizeDto>(result);
            return response;
        }

        public async Task<ProductSizeDto> DeleteAsync(ProductSizeDto productSizeDto)
        {
            var productSize = _mapper.Map<ProductSizeDto, ProductSize>(productSizeDto);

            var result = await _RemoveAsync(productSize);

            var response = _mapper.Map<ProductSize, ProductSizeDto>(result);
            return response;
        }
    }
}

