using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Products.SI.GraphQL;

namespace Products.SI.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQlQuery query)
        {

            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = new ProductsGraphqlApiSchema().ProductsSchema;
                options.Query = query.Query;
                options.OperationName = query.OperationName;
                options.Inputs = query.Variables.ToInputs();
            });

            if (result.Errors?.Count > 0)
            {
                // TODO: Maybe it won't be good in production.
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}
