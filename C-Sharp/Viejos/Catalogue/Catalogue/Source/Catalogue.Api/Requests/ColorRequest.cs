using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ColorRequest
    {
        [Required] public string Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

