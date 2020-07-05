using AutoMapper;
using Catalogue.Common.Dtos.ProductColorDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
{
    public class ProductColorProfile : Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColor, ProductColorDto>();

            CreateMap<ProductColorDto, ProductColor>();
        }
    }
}

