// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductProfileTest : AutoMapperBaseTest<ProductProfile>
    {
        [TestMethod]
        public void MappingProductDtoToProduct()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductDto();
                var model = sut.Map<ProductDto, Product>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductToProductDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProduct();
                var dto = sut.Map<Product, ProductDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

