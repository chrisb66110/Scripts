using AutoMapper;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

