using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.ProductRepository
{
    public class ProductRepository : BaseRepository<Product, long>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var listProduct = await _GetAllAsync();
            
            var response = _mapper.Map<List<Product>, List<ProductDto>>(listProduct);
            return response;
        }

        public async Task<ProductDto> GetByIdAsync(long id)
        {
            var product = await _GetByIdAsync(id);

            var response = _mapper.Map<Product, ProductDto>(product);
            return response;
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            var result = await _AddAsync(product);

            var response = _mapper.Map<Product, ProductDto>(result);
            return response;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            var result = await _UpdateAsync(product);

            var response = _mapper.Map<Product, ProductDto>(result);
            return response;
        }

        public async Task<ProductDto> DeleteAsync(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            var result = await _RemoveAsync(product);

            var response = _mapper.Map<Product, ProductDto>(result);
            return response;
        }
    }
}

