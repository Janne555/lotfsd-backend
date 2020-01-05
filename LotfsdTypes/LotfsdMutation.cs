using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using System.Security.Claims;
using Lotfsd.Types.Models;

namespace Lotfsd.Types
{
  public class LotfsdMutation : ObjectGraphType
  {
    public LotfsdMutation(CharacterSheetService<Info> infoService)
    {
      Name = "Mutation";

      Field<InfoType>(
        "addInfo",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var info = context.GetArgument<Info>("info");
          var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
          info.Owner = owner;
          return infoService.Create(info);
        });

      Field<InfoType>(
        "replaceCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var info = context.GetArgument<Info>("info");
          var id = info.Id;
          var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
          info.Owner = owner;
          return infoService.Replace(owner, info, id);
        });
    }
  }
}
