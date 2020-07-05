// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.ProductSizeDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
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

