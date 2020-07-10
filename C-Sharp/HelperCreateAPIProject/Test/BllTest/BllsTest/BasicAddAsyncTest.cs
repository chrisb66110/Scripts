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
using Npgsql;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = DataTestHelper.GivenTheDefaultMoDtoVar();
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, MoDtoVar>(autoMock, m => m.AddAsync(It.IsAny<MoDtoVar>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task AddAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, Exception>(autoMock, m => m.AddAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }

        [TestMethod]
        public async Task AddAsyncDbUpdateExceptionPathDuplicate()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, BaseConstants.PG_DUPLICATE_ERROR);
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                
                var response = await sut.AddAsync(request);

                Assert.AreEqual(null, response, "response should be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task AddAsyncDbUpdateExceptionPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var innerResponse = new PostgresException("Duplicate throw Exception", null, null, "No Duplicate Exception");
                var responseRepository = new DbUpdateException("Duplicate throw Exception", innerResponse);
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, DbUpdateException>(autoMock, m => m.AddAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}