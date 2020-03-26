namespace Products.DAL
{
    public interface IProductsContextFactory
    {
        ProductsContext GetContext(string connectionString);
    }
}