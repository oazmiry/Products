using Newtonsoft.Json.Linq;

namespace Products.SI.GraphQL.Models
{
    /// <summary>
    /// Structures an incoming query for graphql.
    /// </summary>
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
