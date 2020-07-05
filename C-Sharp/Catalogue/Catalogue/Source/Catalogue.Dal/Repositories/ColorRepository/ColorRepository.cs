using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue.Common.Dtos.ColorDtos;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Repositories.ColorRepository
{
    public class ColorRepository : BaseRepository<Color, long>, IColorRepository
    {
        private readonly IMapper _mapper;

        public ColorRepository(CatalogueContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ColorDto>> GetAllAsync()
        {
            var listColor = await _GetAllAsync();
            
            var response = _mapper.Map<List<Color>, List<ColorDto>>(listColor);
            return response;
        }

        public async Task<ColorDto> GetByIdAsync(long id)
        {
            var color = await _GetByIdAsync(id);

            var response = _mapper.Map<Color, ColorDto>(color);
            return response;
        }

        public async Task<ColorDto> AddAsync(ColorDto colorDto)
        {
            var color = _mapper.Map<ColorDto, Color>(colorDto);

            var result = await _AddAsync(color);

            var response = _mapper.Map<Color, ColorDto>(result);
            return response;
        }

        public async Task<ColorDto> UpdateAsync(ColorDto colorDto)
        {
            var color = _mapper.Map<ColorDto, Color>(colorDto);

            var result = await _UpdateAsync(color);

            var response = _mapper.Map<Color, ColorDto>(result);
            return response;
        }

        public async Task<ColorDto> DeleteAsync(ColorDto colorDto)
        {
            var color = _mapper.Map<ColorDto, Color>(colorDto);

            var result = await _RemoveAsync(color);

            var response = _mapper.Map<Color, ColorDto>(result);
            return response;
        }
    }
}

