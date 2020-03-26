using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.DAL
{
    public interface IProductsRepository
    {
        IEnumerable<Seller> FetchSellersWithItems();
        Seller GetSellerOrDefault(int id);
        Item GetItemOrDefault(int id);
        IEnumerable<Item> FetchAllItems();
    }
}