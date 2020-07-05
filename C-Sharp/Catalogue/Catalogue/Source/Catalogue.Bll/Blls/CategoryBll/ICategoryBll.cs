using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.CategoryDtos;

namespace Catalogue.Bll.Blls.CategoryBll
{
    public interface ICategoryBll
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(long id);
        Task<CategoryDto> AddAsync(CategoryDto categoryDto);
        Task<CategoryDto> UpdateAsync(CategoryDto categoryDto);
        Task<CategoryDto> DeleteAsync(CategoryDto categoryDto);
    }
}

