// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeployBothSystem.Api.Mappings;
using DeployBothSystem.Api.Requests;
using DeployBothSystem.Api.Responses;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Api.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BothProfileTest : AutoMapperBaseTest<BothProfile>
    {
        [TestMethod]
        public void MappingBothRequestToBothDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultBothRequest();
                var dto = sut.Map<BothRequest, BothDto>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingBothDtoToBothResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultBothDto();
                var dto = sut.Map<BothDto, BothResponse>(request);

                CheckAllProperties(request, dto);
            }
        }
    }
}

