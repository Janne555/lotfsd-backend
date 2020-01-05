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
    public LotfsdQuery(CharacterSheetService<Info> infoService)
    {
      Name = "Query";

      Field<InfoType>(
        "info",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context =>
          {
            var userContext = context.UserContext as GraphQLUserContext;
            var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
            return infoService.Get(owner, context.GetArgument<string>("id"));
          });

      Field<ListGraphType<InfoType>>(
        "infos",
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
          return infoService.Get(owner);
        });

      Field<InfoType>(
        "foo",
        resolve: context => new Info {
          Id = "foo",
          Name = "bar",
          Owner = "baz",
          Age = 0,
          Alignment = "chaotic",
          AttackBonus = 3
        });
    }
  }
}