using System;
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
            _connectionString = config.GetConnectionString("Store");
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
                throw new DalException(e.Message, e);
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
                throw new DalException(e.Message, e);
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
                // TODO: Change messages to something more indicative.
                throw new DalException(e.Message, e);
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
                throw new DalException(e.Message, e);
            }
        }
    }
}