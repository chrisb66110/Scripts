using AutoMapper;
using Catalogue2.Common.Dtos.ProductSizeDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSize, ProductSizeDto>();

            CreateMap<ProductSizeDto, ProductSize>();
        }
    }
}

