using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ProductSizeDtos;

namespace Catalogue.Api.Mappings
{
    public class ProductSizeProfile : Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSizeRequest, ProductSizeDto>();

            CreateMap<ProductSizeDto, ProductSizeResponse>();
        }
    }
}

