// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.ProductRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.ProductRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseRepositoryTest<ProductRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListProduct();
                AndIAddRangeTableData(entities);

                var deletedDto = DataTestHelper.GivenTheDefaultListProductDto().First();

                var deletedEntity = entities.First(e => e.Id == deletedDto.Id);
                entities.Remove(deletedEntity);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.DeleteAsync(deletedDto);

                CheckAllProperties(deletedDto, response);

                var tableData = AndIGetTableData<Product>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

