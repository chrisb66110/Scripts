using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.ColorDtos;

namespace Catalogue2.Bll.Blls.ColorBll
{
    public interface IColorBll
    {
        Task<List<ColorDto>> GetAllAsync();
        Task<ColorDto> GetByIdAsync(long id);
        Task<ColorDto> AddAsync(ColorDto colorDto);
        Task<ColorDto> UpdateAsync(ColorDto colorDto);
        Task<ColorDto> DeleteAsync(ColorDto colorDto);
    }
}

