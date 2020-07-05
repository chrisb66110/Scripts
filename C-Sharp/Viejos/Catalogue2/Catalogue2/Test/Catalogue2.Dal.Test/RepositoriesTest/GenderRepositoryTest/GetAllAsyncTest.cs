// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.GenderRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.GenderRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseRepositoryTest<GenderRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListGender();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                CheckAllProperties(entities, response);

                var tableData = AndIGetTableData<Gender>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

