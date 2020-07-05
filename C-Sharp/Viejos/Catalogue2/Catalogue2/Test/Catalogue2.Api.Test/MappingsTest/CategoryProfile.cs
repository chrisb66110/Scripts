// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.CategoryDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CategoryProfileTest : AutoMapperBaseTest<CategoryProfile>
    {
        [TestMethod]
        public void MappingCategoryRequestToCategoryDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultCategoryRequest();
                var dto = sut.Map<CategoryRequest, CategoryDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingCategoryDtoToCategoryResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultCategoryDto();
                var dto = sut.Map<CategoryDto, CategoryResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

