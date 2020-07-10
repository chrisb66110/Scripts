// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBase.Common.Constants;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSpaceBllsVar;
using NSpaceModelsDtosVar;
using NSpaceRepositoriesVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = DataTestHelper.GivenTheDefaultMoDtoVar();
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, MoDtoVar>(autoMock, m => m.UpdateAsync(It.IsAny<MoDtoVar>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, Exception>(autoMock, m => m.UpdateAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }

        [TestMethod]
        public async Task UpdateAsyncDbUpdateConcurrencyExceptionPathDontExist()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = new DbUpdateConcurrencyException(BaseConstants.PG_ERROR_DONT_AFFECT_ENTITY);
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.UpdateAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public async Task UpdateAsyncDbUpdateConcurrencyExceptionPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = new DbUpdateConcurrencyException("Throw Exception");
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, DbUpdateConcurrencyException>(autoMock, m => m.UpdateAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);

                var response = await sut.UpdateAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }
    }
}