// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.AgeGroupBll;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Dal.Repositories.AgeGroupRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.AgeGroupBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<AgeGroupBll>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultAgeGroupDto();
                var idRequest = responseRepository.Id;
                AndIMockDependencyMethod<IAgeGroupRepository, string, AgeGroupDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository, param =>
                {
                    Assert.AreEqual(idRequest, param, "Param is not correct");
                });

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetByIdAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                var idRequest = DataTestHelper.GivenTheDefaultAgeGroupDto().Id;
                AndIMockDependencyMethod<IAgeGroupRepository, AgeGroupDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetByIdAsync(idRequest);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

