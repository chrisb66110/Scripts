// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Dal.Contexts;
using Catalogue.Dal.Models;
using Catalogue.Dal.Repositories.AgeGroupRepository;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.RepositoriesTest.AgeGroupRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseRepositoryTest<AgeGroupRepository, CatalogueContext>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListAgeGroup();
                AndIAddRangeTableData(entities);

                var updatedProperty = "Property3";
                var updatedDto = DataTestHelper.GivenTheDefaultListAgeGroupDto().First();
                updatedDto.Property = updatedProperty;

                entities.First(e => e.Id == updatedDto.Id).Property = updatedProperty;

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(updatedDto);

                CheckAllProperties(updatedDto, response);

                var tableData = AndIGetTableData<AgeGroup>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

