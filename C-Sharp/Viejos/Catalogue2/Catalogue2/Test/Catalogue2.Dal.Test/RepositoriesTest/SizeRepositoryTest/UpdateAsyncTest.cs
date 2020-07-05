// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.SizeRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.SizeRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class UpdateAsyncTest : BaseRepositoryTest<SizeRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListSize();
                AndIAddRangeTableData(entities);

                var updatedProperty = "Property3";
                var updatedDto = DataTestHelper.GivenTheDefaultListSizeDto().First();
                updatedDto.Property = updatedProperty;

                entities.First(e => e.Id == updatedDto.Id).Property = updatedProperty;

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(updatedDto);

                CheckAllProperties(updatedDto, response);

                var tableData = AndIGetTableData<Size>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

