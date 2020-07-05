using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ProductSizeRequest
    {
        [Required] public string Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

