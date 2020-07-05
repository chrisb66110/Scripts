using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.AgeGroupDtos;

namespace Catalogue.Api.Mappings
{
    public class AgeGroupProfile : Profile
    {
        public AgeGroupProfile()
        {
            CreateMap<AgeGroupRequest, AgeGroupDto>();

            CreateMap<AgeGroupDto, AgeGroupResponse>();
        }
    }
}

