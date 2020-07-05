// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ColorDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ColorProfileTest : AutoMapperBaseTest<ColorProfile>
    {
        [TestMethod]
        public void MappingColorRequestToColorDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultColorRequest();
                var dto = sut.Map<ColorRequest, ColorDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingColorDtoToColorResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultColorDto();
                var dto = sut.Map<ColorDto, ColorResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

