using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using APIBase.Dal.Models;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public class NameClassVar : BaseEntity<long>
    {
    	[Required] public string Property { get; set; }
    }
}