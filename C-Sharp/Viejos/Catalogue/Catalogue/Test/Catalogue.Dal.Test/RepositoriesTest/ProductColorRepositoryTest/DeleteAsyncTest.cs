// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;
using Catalogue.Dal.Repositories.ProductColorRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.RepositoriesTest.ProductColorRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeleteAsyncTest : BaseRepositoryTest<ProductColorRepository, CatalogueContext>
    {
        [TestMethod]
        public async Task DeleteAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListProductColor();
                AndIAddRangeTableData(entities);

                var deletedDto = DataTestHelper.GivenTheDefaultListProductColorDto().First();

                var deletedEntity = entities.First(e => e.Id == deletedDto.Id);
                entities.Remove(deletedEntity);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.DeleteAsync(deletedDto);

                CheckAllProperties(deletedDto, response);

                var tableData = AndIGetTableData<ProductColor>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

