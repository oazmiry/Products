using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Exceptions;
using Products.Models.DataStore;

namespace Products.DAL
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly IProductsContextFactory _contextFactory;
        private readonly string _connectionString;

        public ProductsRepository(IProductsContextFactory contextFactory, IConfiguration config)
        {
            _contextFactory = contextFactory;
            _connectionString = config.GetConnectionString("Products");
        }

        public IEnumerable<Seller> FetchSellersWithItems()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Sellers.Include(s => s.Items).ToList();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't fetch sellers joined with items", e);
            }
        }

        public Seller GetSellerWithItemsOrDefault(int id)
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Sellers.Include(s => s.Items).Single(s => s.Id == id);
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't fetch seller joined with items", e);
            }
        }

        public IEnumerable<Item> FetchItemsWithSellers()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Items.Include(i => i.Seller).ToList();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't fetch items joined with sellers", e);
            }
        }

        public Item GetItemWithSellerOrDefault(int id)
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Items.Include(i => i.Seller).Single(i => i.Id == id);
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't fetch item joined with seller", e);
            }
        }

        public Seller AddSeller(string name)
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    var newEntry = context.Sellers.Add(
                        new Seller
                        {
                            Name = name,
                        }
                    );
                    context.SaveChanges();
                    return newEntry.Entity;
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't create new seller", e);
            }
        }

        /// <inheritdoc />
        public void SetupDatabase()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    context.Database.Migrate();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Can't setup database", e);
            }
        }
    }
}