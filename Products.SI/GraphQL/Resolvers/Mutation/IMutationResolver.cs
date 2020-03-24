using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <summary>
    /// Resolves a business logic action for a GraphQL query.
    /// This is necessary to decouple the business logic layer from GraphQL,
    /// which is service-interface-layer-related.
    /// </summary>
    public interface IMutationResolver : IObjectGraphType
    {
        Seller AddSeller(string name);
    }
}