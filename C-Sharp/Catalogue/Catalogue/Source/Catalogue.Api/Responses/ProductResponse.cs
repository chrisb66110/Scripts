using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class ProductResponse
    {
        public long Id { get; set; }
        public string Property { get; set; }
    }
}

