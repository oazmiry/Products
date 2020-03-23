namespace Products.DAL
{
    public interface IStoreContextFactory
    {
        StoreContext GetContext(string connectionString);
    }
}