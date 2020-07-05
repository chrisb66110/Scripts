using AutoMapper;
using Catalogue2.Common.Dtos.CategoryDtos;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Mappings
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

