using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Catalogue.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Color
    {
    	[Required] public string Id { get; set; }
    	[Required] public string Property { get; set; }
    }
}
