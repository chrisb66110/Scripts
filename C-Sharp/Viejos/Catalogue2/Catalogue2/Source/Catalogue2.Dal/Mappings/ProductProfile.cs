using AutoMapper;
using Catalogue2.Common.Dtos.ProductDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
    }
}

