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
    public class AddAsyncTest : BaseRepositoryTest<ProductSizeRepository, CatalogueContext>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListProductSize();
                AndIAddRangeTableData(entities);

                var newId = "Id3";
                var newDto = DataTestHelper.GivenTheDefaultProductSizeDto();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultProductSize();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<ProductSize>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

