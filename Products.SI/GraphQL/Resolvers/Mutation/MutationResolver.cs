using GraphQL;
using GraphQL.Types;
using Products.BL;
using Products.SI.GraphQL.Models.GraphTypes;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <inheritdoc cref="IMutationResolver"/>
    [GraphQLMetadata("Mutation")]
    public class MutationResolver : ObjectGraphType, IMutationResolver
    {
        public MutationResolver(IProductsBusinessLogic bl)
        {
            Field<SellerGraphType>(
                "addSeller",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "name"}
                ),
                resolve: context => bl.AddSeller(context.GetArgument<string>("name"))
            );
        }
    }
}