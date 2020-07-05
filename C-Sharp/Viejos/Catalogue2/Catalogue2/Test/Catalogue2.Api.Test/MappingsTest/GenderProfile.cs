// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class GenderProfileTest : AutoMapperBaseTest<GenderProfile>
    {
        [TestMethod]
        public void MappingGenderRequestToGenderDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultGenderRequest();
                var dto = sut.Map<GenderRequest, GenderDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingGenderDtoToGenderResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultGenderDto();
                var dto = sut.Map<GenderDto, GenderResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

