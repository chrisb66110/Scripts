// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.ProductSizeBll;
using Catalogue2.Common.Dtos.ProductSizeDtos;
using Catalogue2.Dal.Repositories.ProductSizeRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.ProductSizeBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<ProductSizeBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductSizeDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductSizeDto();
                AndIMockDependencyMethod<IProductSizeRepository, ProductSizeDto, ProductSizeDto>(autoMock, m => m.UpdateAsync(It.IsAny<ProductSizeDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultProductSizeDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductSizeRepository, ProductSizeDto>(autoMock, m => m.UpdateAsync(It.IsAny<ProductSizeDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

