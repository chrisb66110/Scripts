using AutoMapper;
using Catalogue2.Common.Dtos.ColorDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>();

            CreateMap<ColorDto, Color>();
        }
    }
}

