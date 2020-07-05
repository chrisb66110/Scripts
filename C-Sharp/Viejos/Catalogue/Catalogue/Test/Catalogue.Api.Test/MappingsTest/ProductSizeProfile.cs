// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Api.Mappings;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ProductSizeDtos;
using Catalogue.Helpers.Test;

namespace Catalogue.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductSizeProfileTest : AutoMapperBaseTest<ProductSizeProfile>
    {
        [TestMethod]
        public void MappingProductSizeRequestToProductSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductSizeRequest();
                var dto = sut.Map<ProductSizeRequest, ProductSizeDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingProductSizeDtoToProductSizeResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductSizeDto();
                var dto = sut.Map<ProductSizeDto, ProductSizeResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

