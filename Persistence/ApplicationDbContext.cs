using Microsoft.EntityFrameworkCore;
using mph_automotive_api.Models;

namespace mph_automotive_api.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SellingPrice> SellingPrices { get; set; }
    };
}
