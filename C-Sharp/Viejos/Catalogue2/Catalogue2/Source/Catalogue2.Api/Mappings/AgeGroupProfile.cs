using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.AgeGroupDtos;

namespace Catalogue2.Api.Mappings
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

