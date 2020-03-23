using System.Collections.Generic;
using Products.Models.DataStore;

namespace Products.BL
{
    public interface IProductsBusinessLogic
    {
        Seller GetSeller(int id);
        IEnumerable<Seller> GetAllSellers();
        Item GetItem(int id);
        IEnumerable<Item> GetAllItems();
        
    }
}