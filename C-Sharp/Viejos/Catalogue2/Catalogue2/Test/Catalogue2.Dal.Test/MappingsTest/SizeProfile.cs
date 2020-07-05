// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Dal.Mappings;
using Catalogue2.Dal.Models;
using Catalogue2.Helpers.Test;

namespace Catalogue2.Dal.Test.MappingsTest
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

