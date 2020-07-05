using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DeployBothSystem.Api.Requests
{
	[ExcludeFromCodeCoverage]
    public class BothRequest
    {
        [Required] public string Id { get; set; }
        [Required] public string Property { get; set; }
    }
}

