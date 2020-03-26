namespace Products.DAL
{
    public interface IProductsContextFactory
    {
        StoreContext GetContext(string connectionString);
    }
}