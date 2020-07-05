// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.ProductColorDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductColorProfileTest : AutoMapperBaseTest<ProductColorProfile>
    {
        [TestMethod]
        public void MappingProductColorDtoToProductColor()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultProductColorDto();
                var model = sut.Map<ProductColorDto, ProductColor>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingProductColorToProductColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultProductColor();
                var dto = sut.Map<ProductColor, ProductColorDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

