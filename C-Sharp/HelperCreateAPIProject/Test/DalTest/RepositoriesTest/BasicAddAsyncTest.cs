// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpaceContextsVar;
using NSpaceModelsVar;
using NSpaceRepositoriesVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AddAsyncTest : BaseRepositoryTest<ClassToTestVar, ContextToUse>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListMoModelVar();
                AndIAddRangeTableData(entities);

                var newId = "Id3";
                var newDto = DataTestHelper.GivenTheDefaultMoDtoVar();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultMoModelVar();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<MoModelVar>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
