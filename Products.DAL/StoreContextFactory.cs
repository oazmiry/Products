using Microsoft.Extensions.Configuration;

namespace Products.DAL
{
    public class StoreContextFactory : IStoreContextFactory
    {
        public StoreContextFactory(IConfiguration config)
        {
        }

        public StoreContext GetContext(string connectionString)
        {
            return new StoreContext(connectionString);
        }
    }
}