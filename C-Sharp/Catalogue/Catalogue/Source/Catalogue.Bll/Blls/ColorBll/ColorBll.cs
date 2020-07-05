using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue.Common.Dtos.ColorDtos;
using Catalogue.Dal.Repositories.ColorRepository;

namespace Catalogue.Bll.Blls.ColorBll
{
    public class ColorBll : IColorBll
    {
        private readonly IColorRepository _colorRepository;

        public ColorBll(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<List<ColorDto>> GetAllAsync()
        {
            var response = await _colorRepository.GetAllAsync();

            return response;
        }

        public async Task<ColorDto> GetByIdAsync(long id)
        {
            var response = await _colorRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<ColorDto> AddAsync(ColorDto colorDto)
        {
            var response = await _colorRepository.AddAsync(colorDto);

            return response;
        }

        public async Task<ColorDto> UpdateAsync(ColorDto colorDto)
        {
            var response = await _colorRepository.UpdateAsync(colorDto);

            return response;
        }

        public async Task<ColorDto> DeleteAsync(ColorDto colorDto)
        {
            var response = await _colorRepository.DeleteAsync(colorDto);

            return response;
        }
    }
}

