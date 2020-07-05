// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.ImageDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ImageProfileTest : AutoMapperBaseTest<ImageProfile>
    {
        [TestMethod]
        public void MappingImageRequestToImageDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultImageRequest();
                var dto = sut.Map<ImageRequest, ImageDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingImageDtoToImageResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultImageDto();
                var dto = sut.Map<ImageDto, ImageResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

