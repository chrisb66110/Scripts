// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.SizeBll;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Dal.Repositories.SizeRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.SizeBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<SizeBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultSizeDto();

                var responseRepository = DataTestHelper.GivenTheDefaultSizeDto();
                AndIMockDependencyMethod<ISizeRepository, SizeDto, SizeDto>(autoMock, m => m.UpdateAsync(It.IsAny<SizeDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultSizeDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<ISizeRepository, SizeDto>(autoMock, m => m.UpdateAsync(It.IsAny<SizeDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

