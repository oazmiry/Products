using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Models.Types
{
    /// <summary>
    /// States which fields are exposed by the api for the <see cref="Seller"/> type.
    /// </summary>
    public class SellerGraphType : ObjectGraphType<Seller>
    {
        public SellerGraphType()
        {
            Field(seller => seller.Id).Description("Seller's id");
            Field(seller => seller.Name).Description("Seller's full name");
            Field(seller => seller.Items).Description("All items the seller owns");
        }
    }
}
