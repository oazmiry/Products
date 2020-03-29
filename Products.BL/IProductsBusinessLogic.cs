using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.BL
{
    public interface IProductsBusinessLogic
    {
        Seller GetSellerWithItems(int id);
        IEnumerable<Seller> GetSellersWithItems();
        Item GetItemWithSeller(int id);
        IEnumerable<Item> GetItemsWithSellers();
        /// <summary>
        /// Some logic to get the app ready to run.
        /// </summary>
        void InitApp();
        Seller AddSeller(string name);
    }
}