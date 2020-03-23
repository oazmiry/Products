using GraphQL;
using Products.Models.DataStore;

namespace Products.SI.GraphQL
{
    /// <summary>
    /// Resolves a business logic action for a GraphQL query.
    /// This is necessary to decouple the business logic layer from GraphQL,
    /// which is service-interface-layer-related.
    /// </summary>
    [GraphQLMetadata("Mutation")]
    public class MutationResolver
    {
        [GraphQLMetadata("addSeller")]
        public Seller AddSeller(string name)
        {
            return null;
        }
    }
}
