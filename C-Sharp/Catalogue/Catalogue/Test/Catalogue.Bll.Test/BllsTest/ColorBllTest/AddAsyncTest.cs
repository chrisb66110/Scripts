// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.ColorBll;
using Catalogue.Common.Dtos.ColorDtos;
using Catalogue.Dal.Repositories.ColorRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.ColorBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<ColorBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = DataTestHelper.GivenTheDefaultColorDto();
                AndIMockDependencyMethod<IColorRepository, ColorDto, ColorDto>(autoMock, m => m.AddAsync(It.IsAny<ColorDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultColorDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IColorRepository, ColorDto>(autoMock, m => m.AddAsync(It.IsAny<ColorDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

