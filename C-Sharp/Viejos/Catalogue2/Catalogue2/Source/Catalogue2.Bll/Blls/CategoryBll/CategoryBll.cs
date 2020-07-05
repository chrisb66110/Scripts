using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.CategoryDtos;
using Catalogue2.Dal.Repositories.CategoryRepository;

namespace Catalogue2.Bll.Blls.CategoryBll
{
    public class CategoryBll : ICategoryBll
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBll(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _categoryRepository.GetAllAsync();

            return response;
        }

        public async Task<CategoryDto> GetByIdAsync(long id)
        {
            var response = await _categoryRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var response = await _categoryRepository.AddAsync(categoryDto);

            return response;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDto)
        {
            var response = await _categoryRepository.UpdateAsync(categoryDto);

            return response;
        }

        public async Task<CategoryDto> DeleteAsync(CategoryDto categoryDto)
        {
            var response = await _categoryRepository.DeleteAsync(categoryDto);

            return response;
        }
    }
}

