using Microsoft.EntityFrameworkCore;

namespace CRUDOperations
{
    internal class ApplicationContext : DbContext
    {
        internal DbSet<User> Users { get; set; } = null!;
        internal ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=client;Username=postgres;Password=1");
        }
    }
}
