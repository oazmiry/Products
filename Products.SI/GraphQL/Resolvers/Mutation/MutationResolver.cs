using GraphQL;
using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <inheritdoc cref="IMutationResolver"/>
    [GraphQLMetadata("Mutation")]
    public class MutationResolver : ObjectGraphType, IMutationResolver
    {
        [GraphQLMetadata("addSeller")]
        public Seller AddSeller(string name)
        {
            return null;
        }
    }
}
