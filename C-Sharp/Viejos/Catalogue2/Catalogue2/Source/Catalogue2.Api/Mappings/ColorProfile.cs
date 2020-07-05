using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ColorDtos;

namespace Catalogue2.Api.Mappings
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorRequest, ColorDto>();

            CreateMap<ColorDto, ColorResponse>();
        }
    }
}

