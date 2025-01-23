using Microsoft.EntityFrameworkCore;
using DigiGameShop.Models;

namespace DigiGameShop.Database
{
    public class DigiGameShopDbContext(DbContextOptions<DigiGameShopDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
        }
    }
}
