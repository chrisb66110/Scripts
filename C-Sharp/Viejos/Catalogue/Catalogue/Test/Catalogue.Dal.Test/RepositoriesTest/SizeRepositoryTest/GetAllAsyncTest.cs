// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;
using Catalogue.Dal.Repositories.SizeRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.RepositoriesTest.SizeRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseRepositoryTest<SizeRepository, CatalogueContext>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListSize();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                CheckAllProperties(entities, response);

                var tableData = AndIGetTableData<Size>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

