using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ImageDtos;

namespace Catalogue.Api.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageRequest, ImageDto>();

            CreateMap<ImageDto, ImageResponse>();
        }
    }
}

