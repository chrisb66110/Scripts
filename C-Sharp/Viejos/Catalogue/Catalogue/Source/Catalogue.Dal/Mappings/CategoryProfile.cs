using AutoMapper;
using Catalogue.Common.Dtos.CategoryDtos;
using Catalogue.Dal.Models;

namespace Catalogue.Dal.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryDto, Category>();
        }
    }
}

