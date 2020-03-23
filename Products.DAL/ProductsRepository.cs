using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Products.Exceptions;
using Products.Models.DataStore;

namespace Products.DAL
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly IStoreContextFactory _contextFactory;
        private readonly string _connectionString;

        public ProductsRepository(IStoreContextFactory contextFactory, IConfiguration config)
        {
            _contextFactory = contextFactory;
            _connectionString = config.GetConnectionString("Store");
        }

        public IEnumerable<Seller> FetchAllSellers()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Sellers.ToList();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException(e.Message, e);
            }
        }

        public IEnumerable<Item> FetchAllItems()
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Items.ToList();
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException(e.Message, e);
            }
        }

        public Seller GetSellerOrDefault(int id)
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Sellers.Find(id);
                }
            }
            catch (SqlException e)
            {
                // TODO: Log
                throw new DalException(e.Message, e);
            }
        }

        public Item GetItemOrDefault(int id)
        {
            try
            {
                using (var context = _contextFactory.GetContext(_connectionString))
                {
                    return context.Items.Find(id);
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