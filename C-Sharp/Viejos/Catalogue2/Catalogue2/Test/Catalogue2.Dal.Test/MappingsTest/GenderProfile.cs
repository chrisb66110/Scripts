// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GenderProfileTest : AutoMapperBaseTest<GenderProfile>
    {
        [TestMethod]
        public void MappingGenderDtoToGender()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultGenderDto();
                var model = sut.Map<GenderDto, Gender>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingGenderToGenderDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultGender();
                var dto = sut.Map<Gender, GenderDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

