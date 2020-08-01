// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpaceModelsDtoVar;
using NSpaceContextsVar;
using NSpaceModelsVar;
using NSpaceRepositoriesVar;
using NSpaceTestHelperVar;
using Newtonsoft.Json;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetLogsAsyncTest : BaseRepositoryTest<ClassToTestVar, ContextToUse>
    {
        [TestMethod]
        public async Task GetLogsAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListMoModelLogVar();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.GetLogsAsync();

                for (int index = 0; index < entities.Count; index++)
                {
                    Assert.AreEqual(entities[index].Id, response[index].Id, $"[{index}].Id is not correct");
                    Assert.AreEqual(entities[index].Username, response[index].Username, $"[{index}].Username is not correct");
                    Assert.AreEqual(entities[index].DateTime, response[index].DateTime, $"[{index}].DateTime is not correct");
                    
                    if ((entities[index].PreviousValue != "null" && response[index].PreviousEntity != null) || entities[index].PreviousEntity != null)
                    {
                        var dto = JsonConvert.DeserializeObject<MoModelToLogDtoVar>(entities[index].PreviousValue);
                        CheckAllProperties(dto, response[index].PreviousEntity);
                    }

                    if ((entities[index].NewValue != "null" && response[index].NewEntity != null) || entities[index].NewEntity != null)
                    {
                        var dto = JsonConvert.DeserializeObject<MoModelToLogDtoVar>(entities[index].NewValue);
                        CheckAllProperties(dto, response[index].NewEntity);
                    }
                }

                var tableData = AndIGetTableData<MoModelLogVar>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}
