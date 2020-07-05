// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Api.Mappings;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Helpers.Test;

namespace Catalogue.Api.Test.MappingsTest
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

