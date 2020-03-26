using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.DAL
{
    public interface IProductsRepository
    {
        IEnumerable<Seller> FetchSellersWithItems();
        Seller GetSellerWithItemsOrDefault(int id);
        IEnumerable<Item> FetchItemsWithSellers();
        Item GetItemWithSellerOrDefault(int id);
        /// <summary>
        /// Setups database (including migrations).
        /// </summary>
        void SetupDatabase();

        int CountSellers();
        int CountItems();
        void SeedDatabase();
    }
}