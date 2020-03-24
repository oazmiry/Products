using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Resolvers.Mutation
{
    /// <summary>
    /// Should be implemented in order to declare that the class holds fields which handle a mutation.
    /// </summary>
    public interface IMutationResolver : IObjectGraphType
    {
    }
}