// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Mappings;
using DeployBothSystem.Dal.Models;
using DeployBothSystem.Helpers.Test;

namespace DeployBothSystem.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BothProfileTest : AutoMapperBaseTest<BothProfile>
    {
        [TestMethod]
        public void MappingBothDtoToBoth()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultBothDto();
                var model = sut.Map<BothDto, Both>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingBothToBothDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultBoth();
                var dto = sut.Map<Both, BothDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

