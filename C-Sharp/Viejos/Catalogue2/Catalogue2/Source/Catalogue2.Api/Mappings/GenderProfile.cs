using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.GenderDtos;

namespace Catalogue2.Api.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GenderRequest, GenderDto>();

            CreateMap<GenderDto, GenderResponse>();
        }
    }
}

