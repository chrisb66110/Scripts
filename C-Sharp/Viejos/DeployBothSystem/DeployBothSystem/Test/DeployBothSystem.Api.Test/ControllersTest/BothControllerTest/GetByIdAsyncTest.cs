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
using DeployBothSystem.Api.Controllers;
using DeployBothSystem.Api.Responses;
using DeployBothSystem.Bll.Blls.BothBll;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Api.Test.ControllersTest.BothControllerTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<BothController>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultBothDto();
                var idRequest = responseBll.Id;
                AndIMockDependencyMethod<IBothBll, string, BothDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseBll, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (BothResponse)response.Value;
                CheckAllProperties(responseBll, responseObject);
            }
        }

        [TestMethod]
        public async Task GetByIdAsyncInvalidDataPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);
                
                var response = await sut.GetByIdAsync(null);

                Assert.AreEqual((int)HttpStatusCode.BadRequest, response.StatusCode, "StatusCode is not correct");

                var responseObject = (string)response.Value;
                Assert.IsTrue(responseObject.Contains(BaseConstants.INVALID_DATA), "Value is not correct");
            }
        }

        [TestMethod]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var idRequest = DataTestHelper.GivenTheDefaultBothDto().Id;
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IBothBll, BothDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}

