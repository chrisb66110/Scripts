// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.AgeGroupDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
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

