using GraphQL;
using GraphQL.Types;
using Products.Models.DataStore;
using Products.SI.GraphQL.Models.Types;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <inheritdoc cref="IMutationResolver"/>
    [GraphQLMetadata("Mutation")]
    public class MutationResolver : ObjectGraphType, IMutationResolver
    {
        public MutationResolver()
        {
            Field<SellerGraphType>(
                "addSeller",
                arguments: new QueryArguments (
                    new QueryArgument<SellerGraphType> { Name = "seller" }
                    )
                );
        }
    }
}
