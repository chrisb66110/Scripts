using AutoMapper;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.CategoryDtos;

namespace Catalogue2.Api.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequest, CategoryDto>();

            CreateMap<CategoryDto, CategoryResponse>();
        }
    }
}

