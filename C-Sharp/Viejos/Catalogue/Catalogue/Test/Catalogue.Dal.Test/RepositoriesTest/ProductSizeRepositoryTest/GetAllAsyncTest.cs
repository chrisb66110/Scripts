// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;
using Catalogue.Dal.Repositories.ProductSizeRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.RepositoriesTest.ProductSizeRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseRepositoryTest<ProductSizeRepository, CatalogueContext>
    {
        [TestMethod]
        public async Task GetAllAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListProductSize();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetAllAsync();

                CheckAllProperties(entities, response);

                var tableData = AndIGetTableData<ProductSize>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

