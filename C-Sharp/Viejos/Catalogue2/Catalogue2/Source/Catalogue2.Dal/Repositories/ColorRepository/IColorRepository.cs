using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ColorDtos;

namespace Catalogue2.Dal.Repositories.ColorRepository
{
    public interface IColorRepository
    {
        Task<List<ColorDto>> GetAllAsync();
        Task<ColorDto> GetByIdAsync(long id);
        Task<ColorDto> AddAsync(ColorDto colorDto);
        Task<ColorDto> UpdateAsync(ColorDto colorDto);
        Task<ColorDto> DeleteAsync(ColorDto colorDto);
    }
}

