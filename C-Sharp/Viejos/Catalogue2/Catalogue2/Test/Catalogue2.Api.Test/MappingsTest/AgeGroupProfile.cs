// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AgeGroupProfileTest : AutoMapperBaseTest<AgeGroupProfile>
    {
        [TestMethod]
        public void MappingAgeGroupRequestToAgeGroupDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultAgeGroupRequest();
                var dto = sut.Map<AgeGroupRequest, AgeGroupDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingAgeGroupDtoToAgeGroupResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultAgeGroupDto();
                var dto = sut.Map<AgeGroupDto, AgeGroupResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

