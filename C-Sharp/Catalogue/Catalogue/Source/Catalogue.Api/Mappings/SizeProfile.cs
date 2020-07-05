using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.SizeDtos;

namespace Catalogue.Api.Mappings
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<SizeRequest, SizeDto>();

            CreateMap<SizeDto, SizeResponse>();
        }
    }
}

