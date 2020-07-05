// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.ProductSizeRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.ProductSizeRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetAllAsyncTest : BaseRepositoryTest<ProductSizeRepository, Catalogue2Context>
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

