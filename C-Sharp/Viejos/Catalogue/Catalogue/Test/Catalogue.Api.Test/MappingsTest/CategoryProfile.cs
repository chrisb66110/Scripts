// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Api.Mappings;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.CategoryDtos;
using Catalogue.Helpers.Test;

namespace Catalogue.Api.Test.MappingsTest
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

