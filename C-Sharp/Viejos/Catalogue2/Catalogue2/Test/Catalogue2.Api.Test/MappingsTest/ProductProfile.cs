// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ProductDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductProfileTest : AutoMapperBaseTest<ProductProfile>
    {
        [TestMethod]
        public void MappingProductRequestToProductDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductRequest();
                var dto = sut.Map<ProductRequest, ProductDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingProductDtoToProductResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultProductDto();
                var dto = sut.Map<ProductDto, ProductResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

