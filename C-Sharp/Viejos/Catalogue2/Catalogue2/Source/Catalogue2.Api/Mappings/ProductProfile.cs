using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ProductDtos;

namespace Catalogue2.Api.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, ProductDto>();

            CreateMap<ProductDto, ProductResponse>();
        }
    }
}

