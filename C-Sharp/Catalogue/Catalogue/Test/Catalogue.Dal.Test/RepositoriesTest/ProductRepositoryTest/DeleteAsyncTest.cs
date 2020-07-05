// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;
using Catalogue.Dal.Repositories.ProductRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.RepositoriesTest.ProductRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseRepositoryTest<ProductRepository, CatalogueContext>
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

