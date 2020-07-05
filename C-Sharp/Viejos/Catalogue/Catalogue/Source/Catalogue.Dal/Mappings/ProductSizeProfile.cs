using AutoMapper;
using Catalogue.Common.Dtos.ProductSizeDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

