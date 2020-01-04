using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using GraphQL.Authorization;

namespace Lotfsd.Types.Models
{
  public class LotfsdQuery : ObjectGraphType
  {
    public LotfsdQuery(CharacterSheetService characterSheetService)
    {
      Name = "Query";

      Field<CharacterSheetType>(
        "characterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context =>
          {
            var userContext = context.UserContext as GraphQLUserContext;
            return characterSheetService.Get(userContext.User.FindFirst(ClaimTypes.Name).Value, context.GetArgument<string>("id"));
          });

      Field<ListGraphType<CharacterSheetType>>(
        "characterSheets",
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          return characterSheetService.Get(userContext.User.FindFirst(ClaimTypes.Name).Value);
        });

      Field<CharacterSheetType>(
        "foo",
        resolve: context => new CharacterSheet { Id = "foo", Name = "bar", Owner = "baz" });
    }
  }
}