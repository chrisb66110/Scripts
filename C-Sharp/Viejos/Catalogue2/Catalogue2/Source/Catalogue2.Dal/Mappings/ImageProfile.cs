using AutoMapper;
using Catalogue2.Common.Dtos.ImageDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();

            CreateMap<ImageDto, Image>();
        }
    }
}

