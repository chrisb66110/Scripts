// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DeployBothSystem.Bll.Blls.BothBll;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Repositories.BothRepository;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Bll.Test.BllsTest.BothBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<BothBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultBothDto();

                var responseRepository = DataTestHelper.GivenTheDefaultBothDto();
                AndIMockDependencyMethod<IBothRepository, BothDto, BothDto>(autoMock, m => m.UpdateAsync(It.IsAny<BothDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultBothDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IBothRepository, BothDto>(autoMock, m => m.UpdateAsync(It.IsAny<BothDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

