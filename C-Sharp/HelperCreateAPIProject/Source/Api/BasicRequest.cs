using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NameSpaceVar
{
	[ExcludeFromCodeCoverage]
    public class NameClassVar
    {
        [Required] public long Id { get; set; }
        [Required] public string Property { get; set; }
    }
}
