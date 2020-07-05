using System.Diagnostics.CodeAnalysis;

namespace Catalogue2.Api.Responses
{
    [ExcludeFromCodeCoverage]
    public class CategoryResponse
    {
        public long Id { get; set; }
        public string Property { get; set; }
    }
}

