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
using NSpaceControllersVar;
using NSpaceResponsesVar;
using NSpaceBllsVar;
using NSpaceModelsDtosVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = DataTestHelper.GivenTheDefaultListMoDtoVar();
                AndIMockDependencyMethod<IBLLVar, List<MoDtoVar>>(autoMock, m => m.GetAllAsync(), responseBll);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode,"StatusCode is not correct");

                var responseObject = (List<MoResponse>) response.Value;
                CheckAllProperties(responseBll, responseObject);
            }
        }

        [TestMethod]
        public async Task GetAllAsyncNoContentPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var responseBll = new List<MoDtoVar>();
                AndIMockDependencyMethod<IBLLVar, List<MoDtoVar>>(autoMock, m => m.GetAllAsync(), responseBll);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                Assert.AreEqual((int)HttpStatusCode.NoContent, response.StatusCode,"StatusCode is not correct");
            }
        }

        [TestMethod]
        public async Task GetAllAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var exception = new Exception("BLL throw Exception");
                AndIMockDependencyMethod<IBLLVar, List<MoDtoVar>, Exception>(autoMock, m => m.GetAllAsync(), exception);

                AndIMockILogger(autoMock);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                Assert.AreEqual((int)HttpStatusCode.InternalServerError, response.StatusCode, "StatusCode is not correct");
                Assert.AreEqual(BaseConstants.ERROR_MESSAGE, response.Value, "Message is not correct");
            }
        }
    }
}