using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.DAL
{
    public interface IProductsRepository
    {
        IEnumerable<Seller> FetchSellersWithItems();
        Seller GetSellerWithItemsOrDefault(int id);
        Item GetItemWithSellerOrDefault(int id);
        IEnumerable<Item> FetchItemsWithSellers();
    }
}