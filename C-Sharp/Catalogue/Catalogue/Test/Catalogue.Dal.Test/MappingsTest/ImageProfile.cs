// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.ImageDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
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

