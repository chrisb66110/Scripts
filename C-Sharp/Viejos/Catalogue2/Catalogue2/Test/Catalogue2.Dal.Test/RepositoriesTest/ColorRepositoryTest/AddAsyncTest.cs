// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.ColorRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.ColorRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseRepositoryTest<ColorRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListColor();
                AndIAddRangeTableData(entities);

                var newId = "Id3";
                var newDto = DataTestHelper.GivenTheDefaultColorDto();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultColor();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<Color>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

