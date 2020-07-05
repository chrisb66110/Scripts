using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ProductSizeDtos;

namespace Catalogue2.Api.Mappings
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

