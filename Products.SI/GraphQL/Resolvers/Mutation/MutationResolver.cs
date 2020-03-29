using GraphQL;
using GraphQL.Types;
using Products.BL;
using Products.SI.GraphQL.Models.GraphTypes;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <summary>
    /// Resolves a business logic action for a GraphQL mutation.
    /// This is necessary to decouple the business logic layer from GraphQL,
    /// which is service-interface-layer-related.
    /// </summary>
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