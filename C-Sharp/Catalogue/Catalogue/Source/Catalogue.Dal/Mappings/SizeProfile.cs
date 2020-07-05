using AutoMapper;
using Catalogue.Common.Dtos.SizeDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDto>();

            CreateMap<SizeDto, Size>();
        }
    }
}

