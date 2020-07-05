// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.AgeGroupBll;
using Catalogue.Common.Dtos.AgeGroupDtos;
using Catalogue.Dal.Repositories.AgeGroupRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.AgeGroupBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<AgeGroupBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultAgeGroupDto();

                var responseRepository = DataTestHelper.GivenTheDefaultAgeGroupDto();
                AndIMockDependencyMethod<IAgeGroupRepository, AgeGroupDto, AgeGroupDto>(autoMock, m => m.UpdateAsync(It.IsAny<AgeGroupDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultAgeGroupDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IAgeGroupRepository, AgeGroupDto>(autoMock, m => m.UpdateAsync(It.IsAny<AgeGroupDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

