using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.SizeDtos;

namespace Catalogue2.Api.Mappings
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

