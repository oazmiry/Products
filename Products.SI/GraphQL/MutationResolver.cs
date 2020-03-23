using GraphQL;
using Products.Models.DataStore;

namespace Products.SI.GraphQL
{
    [GraphQLMetadata("Mutation")]
    public class MutationResolver
    {
        [GraphQLMetadata("addSeller")]
        public Seller AddSeller(string name)
        {
            return null;
        }
    }
}
