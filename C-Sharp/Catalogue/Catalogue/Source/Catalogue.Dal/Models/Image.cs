using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace Catalogue.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Image : BaseEntity<long>
    {
    	[Required] public string Property { get; set; }
    }
}
