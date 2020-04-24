using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
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
    public class DeleteAsyncTest : BaseTest<ClassToTestVar>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = DataTestHelper.GivenTheDefaultMoDtoVar();
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar, MoDtoVar>(autoMock, m => m.DeleteAsync(It.IsAny<MoDtoVar>()), responseRepository, param =>
                {
                    CheckAllProperties(request, param);
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.DeleteAsync(request);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task DeleteAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultMoDtoVar();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IRepositoryVar, MoDtoVar>(autoMock, m => m.DeleteAsync(It.IsAny<MoDtoVar>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.DeleteAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}
