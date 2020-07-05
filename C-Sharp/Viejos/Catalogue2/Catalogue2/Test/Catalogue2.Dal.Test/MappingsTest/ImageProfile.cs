// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.ImageDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ImageProfileTest : AutoMapperBaseTest<ImageProfile>
    {
        [TestMethod]
        public void MappingImageDtoToImage()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultImageDto();
                var model = sut.Map<ImageDto, Image>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingImageToImageDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultImage();
                var dto = sut.Map<Image, ImageDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

