using AutoMapper;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class AgeGroupProfile : Profile
    {
        public AgeGroupProfile()
        {
            CreateMap<AgeGroup, AgeGroupDto>();

            CreateMap<AgeGroupDto, AgeGroup>();
        }
    }
}

