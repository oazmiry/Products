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

        public Seller GetSellerWithItems(int id)
        {
            try
            {
                return _repo.GetSellerWithItemsOrDefault(id);
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }

        public IEnumerable<Seller> GetSellersWithItems()
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

        public Item GetItemWithSeller(int id)
        {
            try
            {
                return _repo.GetItemWithSellerOrDefault(id);
            }
            catch (DalException e)
            {
                throw new BlException(e.Message, e);
            }
        }

        public IEnumerable<Item> GetItemsWithSellers()
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

        public Seller AddSeller(string name)
        {
            try
            {
                return _repo.AddSeller(name);
            }
            catch (DalException e)
            {
                throw new BlException("Failed to add seller", e);
            }
        }

        /// <inheritdoc />
        public void InitApp()
        {
            try
            {
                _repo.SetupDatabase();
            }
            catch (DalException e)
            {
                throw new BlException("Failed to init app", e);
            }
        }
    }
}