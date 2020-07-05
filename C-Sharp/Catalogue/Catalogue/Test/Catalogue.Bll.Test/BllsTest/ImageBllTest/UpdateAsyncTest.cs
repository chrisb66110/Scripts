// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.ImageBll;
using Catalogue.Common.Dtos.ImageDtos;
using Catalogue.Dal.Repositories.ImageRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.ImageBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<ImageBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultImageDto();

                var responseRepository = DataTestHelper.GivenTheDefaultImageDto();
                AndIMockDependencyMethod<IImageRepository, ImageDto, ImageDto>(autoMock, m => m.UpdateAsync(It.IsAny<ImageDto>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task UpdateAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultImageDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IImageRepository, ImageDto>(autoMock, m => m.UpdateAsync(It.IsAny<ImageDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

