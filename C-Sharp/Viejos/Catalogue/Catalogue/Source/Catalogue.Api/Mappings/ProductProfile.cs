using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ProductDtos;

namespace Catalogue.Api.Mappings
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

