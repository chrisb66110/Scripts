// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeployBothSystem.Bll.Blls.BothBll;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Repositories.BothRepository;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Bll.Test.BllsTest.BothBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<BothBll>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListBothDto();

                AndIMockDependencyMethod<IBothRepository, List<BothDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

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
                AndIMockDependencyMethod<IBothRepository, List<BothDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetAllAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}

