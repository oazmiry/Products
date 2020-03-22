namespace Products.Models.DataStore
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
