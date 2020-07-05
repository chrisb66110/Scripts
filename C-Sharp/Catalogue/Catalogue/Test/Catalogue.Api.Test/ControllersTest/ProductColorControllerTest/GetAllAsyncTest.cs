// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Api.Controllers;
using Catalogue.Api.Responses;
using Catalogue.Bll.Blls.ProductColorBll;
using Catalogue.Common.Dtos.ProductColorDtos;
using Catalogue.Helpers.Test;

namespace Catalogue.Api.Test.ControllersTest.ProductColorControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<ProductColorController>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultListProductColorDto();
                AndIMockDependencyMethod<IProductColorBll, List<ProductColorDto>>(autoMock, m => m.GetAllAsync(), responseBll);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode,"StatusCode is not correct");

                var responseObject = (List<ProductColorResponse>) response.Value;
                CheckAllProperties(responseBll, responseObject);
            }
        }

        [TestMethod]
        public async Task GetAllAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IProductColorBll, List<ProductColorDto>>(autoMock, m => m.GetAllAsync(), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}
