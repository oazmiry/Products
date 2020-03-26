using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using Products.BL;
using Products.Models.DataStore;
using Products.SI.GraphQL.Models.GraphTypes;

namespace Products.SI.GraphQL.Resolvers.Query
{
    /// <summary>
    /// Resolves a business logic action for a GraphQL query.
    /// This is necessary to decouple the business logic layer from GraphQL,
    /// which is service-interface-layer-related.
    /// </summary>
    [GraphQLMetadata("Query")]
    public class QueryResolver : ObjectGraphType, IQueryResolver
    {
        public QueryResolver(IProductsBusinessLogic bl)
        {
            Field<ListGraphType<SellerGraphType>>(
                "sellers",
                resolve: _ => bl.GetSellersWithItems()
                );
            Field<SellerGraphType>(
                "seller",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context => bl.GetSellerWithItems(context.GetArgument<int>("id"))
                );
            Field<ListGraphType<ItemGraphType>>(
                "items",
                resolve: _ => bl.GetItemsWithSellers()
                );
            Field<ItemGraphType>(
                "item",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context => bl.GetItemWithSeller(context.GetArgument<int>("id"))
                );
        }
    }
}
