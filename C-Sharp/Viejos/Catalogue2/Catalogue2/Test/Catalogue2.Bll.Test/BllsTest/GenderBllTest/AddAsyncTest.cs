// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue2.Bll.Blls.GenderBll;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Repositories.GenderRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Bll.Test.BllsTest.GenderBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseTest<GenderBll>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = DataTestHelper.GivenTheDefaultGenderDto();
                AndIMockDependencyMethod<IGenderRepository, GenderDto, GenderDto>(autoMock, m => m.AddAsync(It.IsAny<GenderDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IGenderRepository, GenderDto>(autoMock, m => m.AddAsync(It.IsAny<GenderDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.AddAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

