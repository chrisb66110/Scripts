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
    public class DeleteAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var request = DataTestHelper.GivenTheDefaultMoRequestVar();

                var responseBll = DataTestHelper.GivenTheDefaultMoDtoVar();
                AndIMockDependencyMethod<IBLLVar, MoDtoVar, MoDtoVar>(autoMock, m => m.DeleteAsync(It.IsAny<MoDtoVar>()), responseBll, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode, "StatusCode is not correct");

                var responseObject = (MoResponse)response.Value;
                CheckAllProperties(request, responseObject);
            }
        }

        [TestMethod]
        public async Task DeleteAsyncInvalidDataPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoRequestVar();
                
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
                var request = DataTestHelper.GivenTheDefaultMoRequestVar();

                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IBLLVar, MoDtoVar>(autoMock, m => m.DeleteAsync(It.IsAny<MoDtoVar>()), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.DeleteAsync(request);

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}
