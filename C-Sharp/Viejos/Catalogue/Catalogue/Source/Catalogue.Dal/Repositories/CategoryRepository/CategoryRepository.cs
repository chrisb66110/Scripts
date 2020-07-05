using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.CategoryDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.CategoryRepository
{
    public class CategoryRepository : BaseRepository<Category, string>, ICategoryRepository
    {
        private readonly IMapper _mapper;

        public CategoryRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var listCategory = await _GetAllAsync();
            
            var response = _mapper.Map<List<Category>, List<CategoryDto>>(listCategory);
            return response;
        }

        public async Task<CategoryDto> GetByIdAsync(string id)
        {
            var category = await _GetByIdAsync(id);

            var response = _mapper.Map<Category, CategoryDto>(category);
            return response;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);

            var result = await _AddAsync(category);

            var response = _mapper.Map<Category, CategoryDto>(result);
            return response;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);

            var result = await _UpdateAsync(category);

            var response = _mapper.Map<Category, CategoryDto>(result);
            return response;
        }

        public async Task<CategoryDto> DeleteAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryDto, Category>(categoryDto);

            var result = await _RemoveAsync(category);

            var response = _mapper.Map<Category, CategoryDto>(result);
            return response;
        }
    }
}

