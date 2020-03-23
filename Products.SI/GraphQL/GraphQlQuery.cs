using Newtonsoft.Json.Linq;

namespace Products.SI.GraphQL
{
    /// <summary>
    /// Structures an incoming query for graphql.
    /// </summary>
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}