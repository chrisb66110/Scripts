// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.ProductBll;
using Catalogue.Common.Dtos.ProductDtos;
using Catalogue.Dal.Repositories.ProductRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.ProductBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ProductBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductDto();
                AndIMockDependencyMethod<IProductRepository, ProductDto, ProductDto>(autoMock, m => m.AddAsync(It.IsAny<ProductDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultProductDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductRepository, ProductDto>(autoMock, m => m.AddAsync(It.IsAny<ProductDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

