using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Products.DAL
{
    /// <summary>
    /// This class is Microsoft's weird way to enable injecting how the <see cref="DbContext"/>
    /// should be created in design-time.
    /// <remarks>Design-time means while creating migration scripts.</remarks>
    /// </summary>
    public class DesignTimeProductsContextFactory : IDesignTimeDbContextFactory<ProductsContext>
    {
        /// <summary>
        /// A connection string to the migrated db is necessary in order to create a migration.  
        /// Sadly, ef core has no support for inserting the connection string, or any other identifier,
        /// from the command which creates the migration (from the cli).
        /// The <see cref="IDesignTimeDbContextFactory{TContext}"/> interface was intended to support this behavior,
        /// but currently the only options are either reading a file or a environment variable.
        /// I didn't like neither, so I kept this class only so you can put your connection string here before running
        /// the command.
        /// </summary>
        /// <remarks>
        /// Here's a link to a PR which should resolve this issue: https://github.com/dotnet/efcore/issues/8332
        /// </remarks>
        /// <example>Here's the command to run at the cli (from the DAL project directory) to create a migration:
        /// dotnet ef migrations add MigrationClassName
        /// </example>
        public ProductsContext CreateDbContext(string[] args)
        {
            return new ProductsContext(
                "Server=localhost;Database=Products;User=user1;Password=Password1!;Trusted_Connection=True;"
            );
        }
    }
}