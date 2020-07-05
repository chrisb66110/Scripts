// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.ProductBll;
using Catalogue2.Common.Dtos.ProductDtos;
using Catalogue2.Dal.Repositories.ProductRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.ProductBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseTest<ProductBll>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductDto();
                AndIMockDependencyMethod<IProductRepository, ProductDto, ProductDto>(autoMock, m => m.DeleteAsync(It.IsAny<ProductDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultProductDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductRepository, ProductDto>(autoMock, m => m.DeleteAsync(It.IsAny<ProductDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.DeleteAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

