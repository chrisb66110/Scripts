using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.CategoryDtos;

namespace Catalogue.Dal.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(string id);
        Task<CategoryDto> AddAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);
        Task<CategoryDto> DeleteAsync(CategoryDto categoryDto);
    }
}

