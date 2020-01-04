using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using System.Security.Claims;
using Lotfsd.Types.Models;
using GraphQL.Authorization;

namespace Lotfsd.Types
{
  public class LotfsdMutation : ObjectGraphType
  {
    public LotfsdMutation(CharacterSheetService characterSheetService)
    {
      Name = "Mutation";

      Field<CharacterSheetType>(
        "createCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CharacterSheetInputType>> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          characterSheet.Owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
          return characterSheetService.Create(characterSheet);
        });

      Field<CharacterSheetType>(
        "replaceCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CharacterSheetInputType>> { Name = "characterSheet" },
          new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          var id = context.GetArgument<string>("id");
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          return characterSheetService.Replace(userId, characterSheet, id.ToString());
        });
    }
  }
}
