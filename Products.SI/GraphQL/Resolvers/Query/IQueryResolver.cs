using System.Collections.Generic;
using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Resolvers.Query
{
    /// <summary>
    /// Should be implemented in order to declare that the class holds fields which handle a query. 
    /// </summary>
    public interface IQueryResolver : IObjectGraphType
    {
    }
}