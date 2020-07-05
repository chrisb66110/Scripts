using AutoMapper;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.CategoryDtos;

namespace Catalogue.Api.Mappings
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

