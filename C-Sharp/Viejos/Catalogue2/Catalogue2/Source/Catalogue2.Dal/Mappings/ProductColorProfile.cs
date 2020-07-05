using AutoMapper;
using Catalogue2.Common.Dtos.ProductColorDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
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

