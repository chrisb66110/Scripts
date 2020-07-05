// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Api.Mappings;
using Catalogue2.Api.Requests;
using Catalogue2.Api.Responses;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SizeProfileTest : AutoMapperBaseTest<SizeProfile>
    {
        [TestMethod]
        public void MappingSizeRequestToSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultSizeRequest();
                var dto = sut.Map<SizeRequest, SizeDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingSizeDtoToSizeResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultSizeDto();
                var dto = sut.Map<SizeDto, SizeResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

