using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DeployBothSystem.Dal.Models
{
    [ExcludeFromCodeCoverage]
    public class Both
    {
    	[Required] public string Id { get; set; }
    	[Required] public string Property { get; set; }
    }
}
