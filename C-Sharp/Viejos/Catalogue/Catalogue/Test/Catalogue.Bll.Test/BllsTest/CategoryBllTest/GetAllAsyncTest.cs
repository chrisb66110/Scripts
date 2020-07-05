// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Bll.Blls.CategoryBll;
using Catalogue.Common.Dtos.CategoryDtos;
using Catalogue.Dal.Repositories.CategoryRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.CategoryBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseTest<CategoryBll>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultListCategoryDto();

                AndIMockDependencyMethod<ICategoryRepository, List<CategoryDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

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
                AndIMockDependencyMethod<ICategoryRepository, List<CategoryDto>>(autoMock, m => m.GetAllAsync(), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetAllAsync();

                Assert.Fail("Test must have failed");
            }
        }
    }
}

