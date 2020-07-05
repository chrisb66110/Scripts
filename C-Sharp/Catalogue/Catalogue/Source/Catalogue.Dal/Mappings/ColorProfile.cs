using AutoMapper;
using Catalogue.Common.Dtos.ColorDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

