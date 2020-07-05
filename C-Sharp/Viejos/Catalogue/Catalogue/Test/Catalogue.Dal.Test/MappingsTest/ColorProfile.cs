// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.ColorDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
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

