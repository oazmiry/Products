using Microsoft.Extensions.Configuration;

namespace Products.DAL
{
    public class ProductsContextFactory : IProductsContextFactory
    {
        public ProductsContextFactory(IConfiguration config)
        {
        }

        public StoreContext GetContext(string connectionString)
        {
            return new StoreContext(connectionString);
        }
    }
}