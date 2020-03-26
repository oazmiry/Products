using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.DAL
{
    public interface IProductsRepository
    {
        IEnumerable<Seller> FetchSellersWithItems();
        Seller GetSellerWithItemsOrDefault(int id);
        Item GetItemOrDefault(int id);
        IEnumerable<Item> FetchItemsWithSellers();
    }
}