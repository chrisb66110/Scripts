using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.ProductColorDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.ProductColorRepository
{
    public class ProductColorRepository : BaseRepository<ProductColor, long>, IProductColorRepository
    {
        private readonly IMapper _mapper;

        public ProductColorRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductColorDto>> GetAllAsync()
        {
            var listProductColor = await _GetAllAsync();
            
            var response = _mapper.Map<List<ProductColor>, List<ProductColorDto>>(listProductColor);
            return response;
        }

        public async Task<ProductColorDto> GetByIdAsync(long id)
        {
            var productColor = await _GetByIdAsync(id);

            var response = _mapper.Map<ProductColor, ProductColorDto>(productColor);
            return response;
        }

        public async Task<ProductColorDto> AddAsync(ProductColorDto productColorDto)
        {
            var productColor = _mapper.Map<ProductColorDto, ProductColor>(productColorDto);

            var result = await _AddAsync(productColor);

            var response = _mapper.Map<ProductColor, ProductColorDto>(result);
            return response;
        }

        public async Task<ProductColorDto> UpdateAsync(ProductColorDto productColorDto)
        {
            var productColor = _mapper.Map<ProductColorDto, ProductColor>(productColorDto);

            var result = await _UpdateAsync(productColor);

            var response = _mapper.Map<ProductColor, ProductColorDto>(result);
            return response;
        }

        public async Task<ProductColorDto> DeleteAsync(ProductColorDto productColorDto)
        {
            var productColor = _mapper.Map<ProductColorDto, ProductColor>(productColorDto);

            var result = await _RemoveAsync(productColor);

            var response = _mapper.Map<ProductColor, ProductColorDto>(result);
            return response;
        }
    }
}

