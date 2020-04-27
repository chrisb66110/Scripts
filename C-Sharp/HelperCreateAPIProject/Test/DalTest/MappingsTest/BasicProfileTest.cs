// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpaceModelsDtosVar;
using NSpaceMappingsVar;
using NSpaceModelsVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ClassToTestVarTest : AutoMapperBaseTest<ClassToTestVar>
    {
        [TestMethod]
        public void MappingMoDtoVarToMoModelVar()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultMoDtoVar();
                var model = sut.Map<MoDtoVar, MoModelVar>(dto);

                CheckAllProperties(dto, model);
            }
        }

        [TestMethod]
        public void MappingMoModelVarToMoDtoVar()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var model = DataTestHelper.GivenTheDefaultMoModelVar();
                var dto = sut.Map<MoModelVar, MoDtoVar>(model);

                CheckAllProperties(dto, model);
            }
        }
    }
}
