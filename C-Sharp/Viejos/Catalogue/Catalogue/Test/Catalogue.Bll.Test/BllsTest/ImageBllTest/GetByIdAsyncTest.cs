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
    public class GetByIdAsyncTest : BaseTest<ImageBll>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultImageDto();
                var idRequest = responseRepository.Id;
                AndIMockDependencyMethod<IImageRepository, string, ImageDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                var idRequest = DataTestHelper.GivenTheDefaultImageDto().Id;
                AndIMockDependencyMethod<IImageRepository, ImageDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetByIdAsync(idRequest);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

