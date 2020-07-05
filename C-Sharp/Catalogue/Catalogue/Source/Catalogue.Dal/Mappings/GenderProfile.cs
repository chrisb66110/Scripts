using AutoMapper;
using Catalogue.Common.Dtos.GenderDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
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

