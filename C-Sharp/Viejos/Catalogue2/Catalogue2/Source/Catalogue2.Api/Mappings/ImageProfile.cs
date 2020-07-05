using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ImageDtos;

namespace Catalogue2.Api.Mappings
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

