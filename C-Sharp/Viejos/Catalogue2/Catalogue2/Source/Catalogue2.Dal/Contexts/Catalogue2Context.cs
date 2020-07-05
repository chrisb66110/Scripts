using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Contexts
{
    [ExcludeFromCodeCoverage]
    public class Catalogue2Context : DbContext
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

    	public Catalogue2Context(DbContextOptions<Catalogue2Context> options) : base(options) { }

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
