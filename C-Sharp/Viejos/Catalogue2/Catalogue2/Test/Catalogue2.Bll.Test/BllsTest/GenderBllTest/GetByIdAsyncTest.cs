// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.GenderBll;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Repositories.GenderRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.GenderBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<GenderBll>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultGenderDto();
                var idRequest = responseRepository.Id;
                AndIMockDependencyMethod<IGenderRepository, string, GenderDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository, param =>
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
                var idRequest = DataTestHelper.GivenTheDefaultGenderDto().Id;
                AndIMockDependencyMethod<IGenderRepository, GenderDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetByIdAsync(idRequest);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

