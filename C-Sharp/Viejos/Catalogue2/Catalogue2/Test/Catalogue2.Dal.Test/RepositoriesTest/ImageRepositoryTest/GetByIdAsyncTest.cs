// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;
using Catalogue2.Dal.Repositories.ImageRepository;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.RepositoriesTest.ImageRepositoryTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GetByIdAsyncTest : BaseRepositoryTest<ImageRepository, Catalogue2Context>
    {
        [TestMethod]
        public async Task GetByIdAsyncHappyPath()
        {
            using (var autoMock = AutoMock.GetStrict(RegisterBasicDependency))
            {
                var entities = DataTestHelper.GivenTheDefaultListImage();
                AndIAddRangeTableData(entities);

                var sut = GivenTheSystemUnderTest(autoMock);

                var entity = entities.First();
                var idRequest = entity.Id;
                var response = await sut.GetByIdAsync(idRequest);

                CheckAllProperties(entity, response);

                var tableData = AndIGetTableData<Image>();
                CheckAllProperties(entities, tableData);
            }
        }
    }
}

