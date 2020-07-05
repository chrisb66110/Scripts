// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Bll.Blls.AgeGroupBll;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Dal.Repositories.AgeGroupRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.AgeGroupBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<AgeGroupBll>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListAgeGroupDto();

                AndIMockDependencyMethod<IAgeGroupRepository, List<AgeGroupDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                CheckAllProperties(responseRepository, response);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task GetAllAsyncErrorPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IAgeGroupRepository, List<AgeGroupDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetAllAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}

