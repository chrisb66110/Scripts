// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.CategoryBll;
using Catalogue2.Common.Dtos.CategoryDtos;
using Catalogue2.Dal.Repositories.CategoryRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.CategoryBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<CategoryBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = DataTestHelper.GivenTheDefaultCategoryDto();
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto, CategoryDto>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultCategoryDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<ICategoryRepository, CategoryDto>(autoMock, m => m.UpdateAsync(It.IsAny<CategoryDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

