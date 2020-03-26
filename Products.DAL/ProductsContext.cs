using Microsoft.EntityFrameworkCore;
using Products.Models.DataStore;

namespace Products.DAL
{
    public class ProductsContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Item> Items { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public ProductsContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>(seller =>
            {
                seller.HasKey(s => s.Id);
                seller.Property(s => s.Name).IsRequired();
                seller.HasMany(s => s.Items);
            });

            modelBuilder.Entity<Item>(item =>
            {
                item.HasKey(p => p.Id);
                item.HasOne(p => p.Seller)
                    .WithMany(s => s.Items);
                item.Property(i => i.Description).IsRequired();
            });
        }
    }
}
