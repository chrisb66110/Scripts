using AutoMapper;
using Catalogue.Common.Dtos.ImageDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

