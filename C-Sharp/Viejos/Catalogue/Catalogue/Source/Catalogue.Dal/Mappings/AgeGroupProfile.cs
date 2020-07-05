using AutoMapper;
using Catalogue.Common.Dtos.AgeGroupDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

