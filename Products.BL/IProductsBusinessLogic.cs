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
        
    }
}