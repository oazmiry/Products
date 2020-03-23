using System.Collections.Generic;
using GraphQL;
using Products.Models.DataStore;

namespace Products.SI.GraphQL
{
    /// <summary>
    /// Resolves a business logic action for a GraphQL query.
    /// This is necessary to decouple the business logic layer from GraphQL, which is service-interface-layer-related.
    /// </summary>
    [GraphQLMetadata("Query")]
    public class QueryResolver
    {
        public QueryResolver()
        {
            // TODO: Get bl.
        }

        [GraphQLMetadata("items")]
        public IEnumerable<Item> GetItems()
        {
            return Enumerable.Empty<Item>();
        }

        [GraphQLMetadata("item")]
        public IEnumerable<Item> GetItem()
        {
            return null;
        }

        [GraphQLMetadata("sellers")]
        public IEnumerable<Seller> GetSellers() 
        {
            return Enumerable.Empty<Seller>();
        }

        [GraphQLMetadata("seller")]
        public Seller GetSeller(int id)
        {
            return null;
        }
    }
}
