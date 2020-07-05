// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
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
    public class AddAsyncTest : BaseRepositoryTest<BothRepository, DeployBothSystemContext>
    {
        [TestMethod]
        public async Task AddAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListBoth();
                AndIAddRangeTableData(entities);

                var newId = "Id3";
                var newDto = DataTestHelper.GivenTheDefaultBothDto();
                newDto.Id = newId;

                var newRecord = DataTestHelper.GivenTheDefaultBoth();
                newRecord.Id = newId;
                entities.Add(newRecord);

                var sut = GivenTheSystemUnderTest(autoMock);
                var response = await sut.AddAsync(newDto);

                CheckAllProperties(newDto, response);

                var tableData = AndIGetTableData<Both>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

