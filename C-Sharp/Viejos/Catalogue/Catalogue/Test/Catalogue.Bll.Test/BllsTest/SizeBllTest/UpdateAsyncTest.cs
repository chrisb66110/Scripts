// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.SizeBll;
using Catalogue.Common.Dtos.SizeDtos;
using Catalogue.Dal.Repositories.SizeRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.SizeBllTest
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

