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
                AndIMockDependencyMethod<IBLLVar, long, MoDtoVar>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), responseBll, param =>
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
        public async Task GetByIdAsyncNoContentPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var idRequest = 1;

                AndIMockDependencyMethod<IBLLVar, long, MoDtoVar>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), null, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.NoContent, response.StatusCode, "StatusCode is not correct");
            }
        }

        [TestMethod]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var idRequest = DataTestHelper.GivenTheDefaultMoDtoVar().Id;
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IBLLVar, MoDtoVar, Exception>(autoMock, m => m.GetByIdAsync(It.IsAny<long>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}