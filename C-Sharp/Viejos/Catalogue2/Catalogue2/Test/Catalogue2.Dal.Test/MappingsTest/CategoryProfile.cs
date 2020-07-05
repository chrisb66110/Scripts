// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.CategoryDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CategoryProfileTest : AutoMapperBaseTest<CategoryProfile>
    {
        [TestMethod]
        public void MappingCategoryDtoToCategory()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultCategoryDto();
                var model = sut.Map<CategoryDto, Category>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingCategoryToCategoryDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultCategory();
                var dto = sut.Map<Category, CategoryDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

