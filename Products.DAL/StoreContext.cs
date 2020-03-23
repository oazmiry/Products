using Microsoft.EntityFrameworkCore;
using Products.Models.DataStore;

namespace Products.DAL
{
    public class StoreContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Item> Items { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public StoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().HasKey(s => s.Id);

            modelBuilder.Entity<Item>().HasKey(p => p.Id);
            modelBuilder.Entity<Item>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Items);
        }
    }
}
