using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ProductColorDtos;

namespace Catalogue2.Api.Mappings
{
    public class ProductColorProfile : Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColorRequest, ProductColorDto>();

            CreateMap<ProductColorDto, ProductColorResponse>();
        }
    }
}

