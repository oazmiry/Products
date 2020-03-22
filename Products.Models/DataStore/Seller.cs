using System.Collections.Generic;

namespace Products.Models.DataStore
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}