// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.AgeGroupRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.AgeGroupRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseRepositoryTest<AgeGroupRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListAgeGroup();
                AndIAddRangeTableData(entities);

                var newId = "Id3";
                var newDto = DataTestHelper.GivenTheDefaultAgeGroupDto();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultAgeGroup();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<AgeGroup>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

