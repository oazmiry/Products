using Microsoft.EntityFrameworkCore;
using Products.Models.DataStore;

namespace Products.DAL
{
    public class ProductsContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Item> Items { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        /// <summary>
        /// This is necessary to inject options such as in memory and so from tests.
        /// </summary>
        public ProductsContext(DbContextOptions options)
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

            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    Id = 1,
                    Name = "Me",
                },
                new Seller
                {
                    Id = 2,
                    Name = "Him",
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Description = "My first thing",
                    SellerId = 1,
                },
                new Item
                {
                    Id = 2,
                    Description = "My second thing",
                    SellerId = 1,
                },
                new Item
                {
                    Id = 3,
                    Description = "His only thing",
                    SellerId = 2,
                }
            );
        }
    }
}
