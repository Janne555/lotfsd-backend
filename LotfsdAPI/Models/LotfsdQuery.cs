using GraphQL.Types;
using LotfsdAPI.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace LotfsdAPI.Models
{
  public class LotfsdQuery : ObjectGraphType
  {
    public LotfsdQuery(CharacterSheetService characterSheetService, IHttpContextAccessor contextAccessor)
    {
      Field<CharacterSheetType>(
        "characterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => characterSheetService.GetGraphQL(context.GetArgument<string>("id")));

      Field<ListGraphType<CharacterSheetType>>(
        "characterSheets",
        resolve: context => characterSheetService.Get(contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value));
    }
  }
}