// ReSharper disable ConvertToUsingDeclaration

using System.Diagnostics.CodeAnalysis;
using APIBaseTest;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpaceMappingsVar;
using NSpaceRequestsVar;
using NSpaceResponsesVar;
using NSpaceModelsDtosVar;
using NSpaceTestHelperVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ClassToTestVarTest : AutoMapperBaseTest<ClassToTestVar>
    {
        [TestMethod]
        public void MappingMoRequestVarToMoDtoVar()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var request = DataTestHelper.GivenTheDefaultMoRequestVar();
                var dto = sut.Map<MoRequestVar, MoDtoVar>(request);

                CheckAllProperties(request, dto);
            }
        }

        [TestMethod]
        public void MappingMoDtoVarToMoResponse()
        {
            using (var autoMock = AutoMock.GetStrict())
            {
                var sut = GivenTheSystemUnderTest(autoMock);

                var dto = DataTestHelper.GivenTheDefaultMoDtoVar();
                var response = sut.Map<MoDtoVar, MoResponse>(dto);

                CheckAllProperties(dto, response);
            }
        }
    }
}