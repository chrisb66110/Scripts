using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NSpaceRequestsVar;
using NSpaceResponsesVar;
using NSpaceModelsDtosVar;
using NSpaceModelsVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public static class DataTestHelper
    {
        public static MoDtoVar GivenTheDefaultMoDtoVar()
        {
            var response = new MoDtoVar()
            {
                Id = "Id",
                Property = "Property"
            };

            return response;
        }

        public static List<MoDtoVar> GivenTheDefaultListMoDtoVar()
        {
            var dto1 = GivenTheDefaultMoDtoVar();
            dto1.Id = "Id1";

            var dto2 = GivenTheDefaultMoDtoVar();
            dto1.Id = "Id2";

            var response = new List<MoDtoVar>()
            {
                dto1,
                dto2
            };

            return response;
        }

        public static MoResponseVar GivenTheDefaultMoResponseVar()
        {
            var response = new MoResponseVar()
            {
                Id = "Id",
                Property = "Property"
            };

            return response;
        }

        public static List<MoResponseVar> GivenTheDefaultListMoResponseVar()
        {
            var response1 = GivenTheDefaultMoResponseVar();
            response1.Id = "Id1";

            var response2 = GivenTheDefaultMoResponseVar();
            response1.Id = "Id2";

            var response = new List<MoResponseVar>()
            {
                response1,
                response2
            };

            return response;
        }

        public static MoRequestVar GivenTheDefaultMoRequestVar()
        {
            var response = new MoRequestVar()
            {
                Id = "Id",
                Property = "Property"
            };

            return response;
        }

        public static MoModelVar GivenTheDefaultMoModelVar()
        {
            var response = new MoModelVar()
            {
                Id = "Id",
                Property = "Property"
            };

            return response;
        }

        public static List<MoModelVar> GivenTheDefaultListMoModelVar()
        {
            var model1 = GivenTheDefaultMoModelVar();
            model1.Id = "Id1";

            var model2 = GivenTheDefaultMoModelVar();
            model1.Id = "Id2";

            var response = new List<MoModelVar>()
            {
                model1,
                model2
            };

            return response;
        }
    }
}
