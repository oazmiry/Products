﻿using System.Collections.Generic;
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

        public int CountSellers()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Sellers.Count();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't count sellers", e);
            }
        }

        public int CountItems()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Items.Count();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Couldn't count items", e);
            }
        }

        public void SeedDatabase()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    context.Sellers.AddRange(new Seller
                    {
                        Name = "Me",
                        Items = new[]
                        {
                            new Item
                            {
                                Description = "My first thing",
                            },
                            new Item
                            {
                                Description = "My second thing",
                            },
                        },
                    }, new Seller
                    {
                        Name = "Him",
                        Items = new[]
                        {
                            new Item
                            {
                                Description = "His only thing"
                            },
                        },
                    });
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException("Failed to seed with products", e);
            }
        }
    }
}