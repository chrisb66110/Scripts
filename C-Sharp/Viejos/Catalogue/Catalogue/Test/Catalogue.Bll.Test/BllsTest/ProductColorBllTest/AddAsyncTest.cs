// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.ProductColorBll;
using Catalogue.Common.Dtos.ProductColorDtos;
using Catalogue.Dal.Repositories.ProductColorRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.ProductColorBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ProductColorBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var responseRepository = DataTestHelper.GivenTheDefaultProductColorDto();
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto, ProductColorDto>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultProductColorDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IProductColorRepository, ProductColorDto>(autoMock, m => m.AddAsync(It.IsAny<ProductColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

