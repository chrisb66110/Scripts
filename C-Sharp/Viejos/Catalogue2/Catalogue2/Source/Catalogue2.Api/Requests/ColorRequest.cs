using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue2.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class ColorRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

