// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Api.Mappings;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Common.Dtos.GenderDtos;
using Catalogue.Helpers.Test;

namespace Catalogue.Api.Test.MappingsTest
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

