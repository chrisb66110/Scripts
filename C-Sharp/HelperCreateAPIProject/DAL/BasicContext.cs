using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public class NameClassVar : DbContext
    {
    	public NameClassVar(DbContextOptions<NameClassVar> options) : base(options) { }
    }
}