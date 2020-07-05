// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue.Common.Dtos.SizeDtos;
using Catalogue.Dal.Mappings;
using Catalogue.Dal.Models;
using Catalogue.Helpers.Test;

namespace Catalogue.Dal.Test.MappingsTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SizeProfileTest : AutoMapperBaseTest<SizeProfile>
    {
        [TestMethod]
        public void MappingSizeDtoToSize()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultSizeDto();
                var model = sut.Map<SizeDto, Size>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingSizeToSizeDto()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultSize();
                var dto = sut.Map<Size, SizeDto>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}

