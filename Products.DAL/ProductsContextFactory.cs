using Microsoft.Extensions.Configuration;

namespace Products.DAL
{
    public class ProductsContextFactory : IProductsContextFactory
    {
        public ProductsContextFactory(IConfiguration config)
        {
        }

        public ProductsContext GetContext(string connectionString)
        {
            return new ProductsContext(connectionString);
        }
    }
}