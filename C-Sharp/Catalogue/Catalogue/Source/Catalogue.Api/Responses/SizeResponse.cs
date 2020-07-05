using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class SizeResponse
    {
        public long Id { get; set; }
        public string Property { get; set; }
    }
}

