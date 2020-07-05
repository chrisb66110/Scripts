// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.ColorDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ColorProfileTest : AutoMapperBaseTest<ColorProfile>
    {
        [TestMethod]
        public void MappingColorDtoToColor()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultColorDto();
                var model = sut.Map<ColorDto, Color>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingColorToColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultColor();
                var dto = sut.Map<Color, ColorDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

