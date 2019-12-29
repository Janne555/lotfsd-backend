using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using LotfsdAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LotfsdAPI.Controllers
{
  [Route("[controller]")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class GraphQLController : Controller
  {
    private readonly IDocumentExecuter _documentExcecuter;
    private readonly ISchema _schema;

    public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
    {
      _schema = schema;
      _documentExcecuter = documentExecuter;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
      if (query == null)
      {
        throw new ArgumentNullException(nameof(query));
      }

      var inputs = query.Variables.ToInputs();


      var executionOptions = new ExecutionOptions
      {
        Schema = _schema,
        Query = query.Query,
        Inputs = inputs,
        UserContext = new GraphQLUserContext
        {
          User = User
        }
      };


      var result = await _documentExcecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

      if (result.Errors?.Count > 0)
      {
        return BadRequest(result);
      }

      return Ok(result);
    }
  }
}