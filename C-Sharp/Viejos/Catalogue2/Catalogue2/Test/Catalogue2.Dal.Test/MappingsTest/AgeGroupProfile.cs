// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AgeGroupProfileTest : AutoMapperBaseTest<AgeGroupProfile>
    {
        [TestMethod]
        public void MappingAgeGroupDtoToAgeGroup()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultAgeGroupDto();
                var model = sut.Map<AgeGroupDto, AgeGroup>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingAgeGroupToAgeGroupDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultAgeGroup();
                var dto = sut.Map<AgeGroup, AgeGroupDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

