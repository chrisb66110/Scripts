using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ProductColorDtos;

namespace Catalogue.Api.Mappings
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

