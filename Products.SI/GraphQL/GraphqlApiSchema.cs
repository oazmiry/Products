﻿using GraphQL.Types;

namespace Products.SI.GraphQL
{
    /// <summary>
    /// Holds the GraphQL schema for this project's Api.
    /// </summary>
    public class GraphqlApiSchema
    {
        public ISchema Schema { get; }

        public GraphqlApiSchema() 
        {
            Schema = global::GraphQL.Types.Schema.For(@"
          type Item {
            id: ID
            description: String,
            seller: Seller
          }

          type Seller {
            id: ID,
            name: String,
            items: [Item]
          }

          type Mutation {
            addSeller(name: String): Seller
          }

          type Query {
              items: [Book]
              seller(id: ID): Seller,
              sellers: [Seller]
          }
      ", schemaBuilder =>
            {
                schemaBuilder.Types.Include<QueryResolver>();
                schemaBuilder.Types.Include<MutationResolver>();
            });
        }
    }
}
