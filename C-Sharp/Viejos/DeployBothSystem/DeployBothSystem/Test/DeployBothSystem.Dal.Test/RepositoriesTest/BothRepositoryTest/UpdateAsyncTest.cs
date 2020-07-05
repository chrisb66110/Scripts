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
    public class UpdateAsyncTest : BaseRepositoryTest<BothRepository, DeployBothSystemContext>
    {
        [TestMethod]
        public async Task UpdateAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListBoth();
                AndIAddRangeTableData(entities);

                var updatedProperty = "Property3";
                var updatedDto = DataTestHelper.GivenTheDefaultListBothDto().First();
                updatedDto.Property = updatedProperty;

                entities.First(e => e.Id == updatedDto.Id).Property = updatedProperty;

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.UpdateAsync(updatedDto);

                CheckAllProperties(updatedDto, response);

                var tableData = AndIGetTableData<Both>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

