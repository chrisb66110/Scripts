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
using Catalogue2.Bll.Blls.ProductSizeBll;
using Catalogue2.Common.Dtos.ProductSizeDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.ControllersTest.ProductSizeControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ProductSizeController>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var request = DataTestHelper.GivenTheDefaultProductSizeRequest();

                var responseBll = DataTestHelper.GivenTheDefaultProductSizeDto();
                AndIMockDependencyMethod<IProductSizeBll, ProductSizeDto, ProductSizeDto>(autoMock, m => m.AddAsync(It.IsAny<ProductSizeDto>()), responseBll, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.AddAsync(request);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (ProductSizeResponse)response.Value;
                CheckAllProperties(request, responseObject);
            }
        }

        [TestMethod]
        public async Task AddAsyncInvalidDataPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductSizeRequest();
                
                var sut = GivenTheSystemUnderTest(autoMock);
                sut.ModelState.AddModelError("Id", "The Id field is required.");

                var response = await sut.AddAsync(request);

                Assert.AreEqual((int)HttpStatusCode.BadRequest, response.StatusCode, "StatusCode is not correct");

                var responseObject = (string)response.Value;
                Assert.IsTrue(responseObject.Contains(BaseConstants.INVALID_DATA), "Value is not correct");
            }
        }

        [TestMethod]
        public async Task AddAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var request = DataTestHelper.GivenTheDefaultProductSizeRequest();

                var exception = new Exception("Bll throw Exception");
                AndIMockDependencyMethod<IProductSizeBll, ProductSizeDto>(autoMock, m => m.AddAsync(It.IsAny<ProductSizeDto>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.AddAsync(request);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}

