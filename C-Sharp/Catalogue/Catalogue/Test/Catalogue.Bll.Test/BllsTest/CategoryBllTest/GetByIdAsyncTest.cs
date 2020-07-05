// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.CategoryBll;
using Catalogue.Common.Dtos.CategoryDtos;
using Catalogue.Dal.Repositories.CategoryRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.CategoryBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseTest<CategoryBll>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var responseRepository = DataTestHelper.GivenTheDefaultCategoryDto();
                var idRequest = responseRepository.Id;
                AndIMockDependencyMethod<ICategoryRepository, string, CategoryDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository, param =>
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
                var idRequest = DataTestHelper.GivenTheDefaultCategoryDto().Id;
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto>(autoMock, m => m.GetByIdAsync(It.IsAny<string>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.GetByIdAsync(idRequest);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

