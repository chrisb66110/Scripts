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
    public class AddAsyncTest : BaseTest<AgeGroupBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultAgeGroupDto();

                var responseRepository = DataTestHelper.GivenTheDefaultAgeGroupDto();
                AndIMockDependencyMethod<IAgeGroupRepository, AgeGroupDto, AgeGroupDto>(autoMock, m => m.AddAsync(It.IsAny<AgeGroupDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultAgeGroupDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IAgeGroupRepository, AgeGroupDto>(autoMock, m => m.AddAsync(It.IsAny<AgeGroupDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

