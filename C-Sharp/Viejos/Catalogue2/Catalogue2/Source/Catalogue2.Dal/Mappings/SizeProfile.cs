using AutoMapper;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
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

