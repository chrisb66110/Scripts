using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.GenderDtos;

namespace Catalogue.Api.Mappings
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

