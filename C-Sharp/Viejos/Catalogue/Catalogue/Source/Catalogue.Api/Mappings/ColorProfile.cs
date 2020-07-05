using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ColorDtos;

namespace Catalogue.Api.Mappings
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

