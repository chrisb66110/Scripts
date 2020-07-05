using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace Catalogue2.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class ProductColor : BaseEntity<long>
    {
    	[Required] public string Property { get; set; }
    }
}
