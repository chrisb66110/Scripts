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
    public class DeleteAsyncTest : BaseTest<CategoryBll>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = DataTestHelper.GivenTheDefaultCategoryDto();
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, CategoryDto>(autoMock, m => m.DeleteAsync(It.IsAny<CategoryDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto>(autoMock, m => m.DeleteAsync(It.IsAny<CategoryDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.DeleteAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

