using AutoMapper;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderDto>();

            CreateMap<GenderDto, Gender>();
        }
    }
}

