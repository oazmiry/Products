using System;
using System.Collections.Generic;
using Products.DAL;
using Products.Exceptions;
using Products.Models.DataStore;

namespace Products.BL
{
    public class ProductsBusinessLogic : IProductsBusinessLogic
    {
        private readonly IProductsRepository _repo;

        public ProductsBusinessLogic(IProductsRepository repo)
        {
            _repo = repo;
        }

        public Seller GetSeller(int id)
        {
            try
            {
                return _repo.GetSellerOrDefault(id);
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }

        public IEnumerable<Seller> GetAllSellers()
        {
            try
            {
                return _repo.FetchSellersWithItems();
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }

        public Item GetItem(int id)
        {
            try
            {
                return _repo.GetItemOrDefault(id);
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }

        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                return _repo.FetchItemsWithSellers();
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }
    }
}
