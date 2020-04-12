using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NSpaceModelsVar;

namespace NameSpaceVar
{
    [ExcludeFromCodeCoverage]
    public class NameClassVar : DbContext
    {
TablesPropertyVar
    	public NameClassVar(DbContextOptions<NameClassVar> options) : base(options) { }

    	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }

        public async Task MigrationsAsync()
        {
            if (Database.GetPendingMigrations().Any())
            {
                await Database.MigrateAsync();
            }
        }
    }
}