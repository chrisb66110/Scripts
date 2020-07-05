using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue2.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class CategoryRequest
    {
        [Required] public long Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

