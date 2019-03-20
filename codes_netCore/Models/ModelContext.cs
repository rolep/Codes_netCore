using Microsoft.EntityFrameworkCore;

namespace codes_netCore.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Code> Codes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=codes;Username=postgres;Password=qq");
        }
    }
}
