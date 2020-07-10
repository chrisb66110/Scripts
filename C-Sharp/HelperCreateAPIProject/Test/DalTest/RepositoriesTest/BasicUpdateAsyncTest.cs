// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    public class UpdateAsyncTest : BaseRepositoryTest<ClassToTestVar, ContextToUse>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListMoModelVar();
                AndIAddRangeTableData(entities);

                var updatedProperty = "Property3";
                var updatedDto = DataTestHelper.GivenTheDefaultListMoDtoVar().First();
                updatedDto.Property0 = updatedProperty;

                entities.First(e => e.Id == updatedDto.Id).Property0 = updatedProperty;

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(updatedDto);

                CheckAllProperties(updatedDto, response);

                var tableData = AndIGetTableData<MoModelVar>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}