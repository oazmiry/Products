using GraphQL;
using GraphQL.Types;
using Products.SI.GraphQL.Resolvers.Mutation;
using Products.SI.GraphQL.Resolvers.Query;

namespace Products.SI.GraphQL
{
    /// <summary>
    /// Holds the GraphQL schema for this project's Api.
    /// </summary>
    public class GraphqlApiSchema : Schema
    {
        public GraphqlApiSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = DependencyResolver.Resolve<IQueryResolver>();
            Mutation = DependencyResolver.Resolve<IMutationResolver>();
        }
    }
}