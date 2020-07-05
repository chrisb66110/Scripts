using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeployBothSystem.Dal.Models;

namespace DeployBothSystem.Dal.Contexts
{
    [ExcludeFromCodeCoverage]
    public class DeployBothSystemContext : DbContext
    {
        public DbSet<Both> Boths { get; set; }

    	public DeployBothSystemContext(DbContextOptions<DeployBothSystemContext> options) : base(options) { }

    	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }

        public async Task MigrationsAsync()
        {
            if (Database.GetPendingMigrations().AsQueryable().Any())
            {
                await Database.MigrateAsync();
            }
        }
    }
}
