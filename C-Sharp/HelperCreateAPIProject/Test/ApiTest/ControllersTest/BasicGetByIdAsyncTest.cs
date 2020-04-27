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
using NSpaceControllersVar;
using NSpaceResponsesVar;
using NSpaceBllsVar;
using NSpaceModelsDtosVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultMoDtoVar();
                var idRequest = responseBll.Id;
                AndIMockDependencyMethod<IBLLVar, string, MoDtoVar>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseBll, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (MoResponse)response.Value;
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
                var idRequest = DataTestHelper.GivenTheDefaultMoDtoVar().Id;
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IBLLVar, MoDtoVar>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}
