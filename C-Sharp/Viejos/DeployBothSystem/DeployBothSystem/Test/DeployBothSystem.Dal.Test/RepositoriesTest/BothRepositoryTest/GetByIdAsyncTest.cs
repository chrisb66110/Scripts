// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeployBothSystem.Dal.Contexts;
using DeployBothSystem.Dal.Models;
using DeployBothSystem.Dal.Repositories.BothRepository;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Dal.Test.RepositoriesTest.BothRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseRepositoryTest<BothRepository, DeployBothSystemContext>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListBoth();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);

                var entity = entities.First();
                var idRequest = entity.Id;
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(entity, response);

                var tableData = AndIGetTableData<Both>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

