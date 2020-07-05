using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ColorDtos;

namespace Catalogue.Dal.Repositories.ColorRepository
{
    public interface IColorRepository
    {
        Task<List<ColorDto>> GetAllAsync();
        Task<ColorDto> GetByIdAsync(string id);
        Task<ColorDto> AddAsync(ColorDto colorDto);
        Task<ColorDto> UpdateAsync(ColorDto colorDto);
        Task<ColorDto> DeleteAsync(ColorDto colorDto);
    }
}

