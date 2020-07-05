// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ProductColorDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductColorProfileTest : AutoMapperBaseTest<ProductColorProfile>
    {
        [TestMethod]
        public void MappingProductColorRequestToProductColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductColorRequest();
                var dto = sut.Map<ProductColorRequest, ProductColorDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingProductColorDtoToProductColorResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductColorDto();
                var dto = sut.Map<ProductColorDto, ProductColorResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

