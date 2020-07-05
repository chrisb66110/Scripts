// ReSharper disable ConvertToUsingDeclaration

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Catalogue.Bll.Blls.GenderBll;
using Catalogue.Common.Dtos.GenderDtos;
using Catalogue.Dal.Repositories.GenderRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Bll.Test.BllsTest.GenderBllTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseTest<GenderBll>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = DataTestHelper.GivenTheDefaultGenderDto();
                AndIMockDependencyMethod<IGenderRepository, GenderDto, GenderDto>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository, param =>
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
                var request = DataTestHelper.GivenTheDefaultGenderDto();

                var responseRepository = new Exception("Repository throw Exception");
                AndIMockDependencyMethod<IGenderRepository, GenderDto>(autoMock, m => m.UpdateAsync(It.IsAny<GenderDto>()), responseRepository);

                var sut = GivenTheSystemUnderTest(autoMock);
                await sut.UpdateAsync(request);

                Assert.Fail("Test must have failed");
            }
        }
    }
}

