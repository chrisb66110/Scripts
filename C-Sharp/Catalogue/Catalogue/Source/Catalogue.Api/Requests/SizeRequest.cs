using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class SizeRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

