// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.ProductSizeDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductSizeProfileTest : AutoMapperBaseTest<ProductSizeProfile>
    {
        [TestMethod]
        public void MappingProductSizeDtoToProductSize()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductSizeDto();
                var model = sut.Map<ProductSizeDto, ProductSize>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductSizeToProductSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductSize();
                var dto = sut.Map<ProductSize, ProductSizeDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

