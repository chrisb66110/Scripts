using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ColorDtos;

namespace Catalogue.Bll.Blls.ColorBll
{
    public interface IColorBll
    {
        Task<List<ColorDto>> GetAllAsync();
        Task<ColorDto> GetByIdAsync(string id);
        Task<ColorDto> AddAsync(ColorDto colorDto);
        Task<ColorDto> UpdateAsync(ColorDto colorDto);
        Task<ColorDto> DeleteAsync(ColorDto colorDto);
    }
}

