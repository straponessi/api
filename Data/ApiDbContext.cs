using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        public DbSet<BankTransaсtion> BankTransaсtions => Set<BankTransaсtion>();

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.BankAccount)
                .WithOne(b => b.Player)
                .HasForeignKey<BankAccount>(b => b.PlayerId);
        }
    }
}
