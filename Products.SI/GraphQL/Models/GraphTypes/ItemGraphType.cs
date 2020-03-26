using GraphQL.Types;
using Products.Models.DataStore;

namespace Products.SI.GraphQL.Models.GraphTypes
{
    /// <summary>
    /// Structures which fields are exposed by the api for the <see cref="Item"/> type.
    /// </summary>
    public class ItemGraphType : ObjectGraphType<Item>
    {
        public ItemGraphType()
        {
            Field(item => item.Id).Description("Item's id");
            Field(item => item.Description).Description("Describes the item");
            Field(item => item.SellerId).Description("Item's owner id");
            Field(item => item.Seller).Description("Item's seller object");
        }
    }
}
