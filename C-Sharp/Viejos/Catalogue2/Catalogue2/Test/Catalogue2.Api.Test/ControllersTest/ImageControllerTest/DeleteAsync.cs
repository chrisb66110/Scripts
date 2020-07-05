// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Api.Controllers;
using Catalogue2.Api.Responses;
using Catalogue2.Bll.Blls.ImageBll;
using Catalogue2.Common.Dtos.ImageDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.ControllersTest.ImageControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseTest<ImageController>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var request = DataTestHelper.GivenTheDefaultImageRequest();

                var responseBll = DataTestHelper.GivenTheDefaultImageDto();
                AndIMockDependencyMethod<IImageBll, ImageDto, ImageDto>(autoMock, m => m.DeleteAsync(It.IsAny<ImageDto>()), responseBll, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (ImageResponse)response.Value;
                CheckAllProperties(request, responseObject);
            }
        }

        [TestMethod]
        public async Task DeleteAsyncInvalidDataPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultImageRequest();
                
                var sut = GivenTheSystemUnderTest(autoMock);
                sut.ModelState.AddModelError("Id", "The Id field is required.");

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual((int)HttpStatusCode.BadRequest, response.StatusCode, "StatusCode is not correct");

                var responseObject = (string)response.Value;
                Assert.IsTrue(responseObject.Contains(BaseConstants.INVALID_DATA), "Value is not correct");
            }
        }

        [TestMethod]
        public async Task DeleteAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var request = DataTestHelper.GivenTheDefaultImageRequest();

                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IImageBll, ImageDto>(autoMock, m => m.DeleteAsync(It.IsAny<ImageDto>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}

