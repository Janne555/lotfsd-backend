using System;
using System.Security.Claims;
using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using Lotfsd.Types.Models;

namespace Lotfsd.Types
{
  public class LotfsdMutation : ObjectGraphType
  {
    public LotfsdMutation(DataStore dataStore)
    {
      Name = "Mutation";

      Field<ListGraphType<NonNullGraphType<CharacterSheetType>>>(
        "createCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CharacterSheetInputType>> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          characterSheet.Guid = Guid.NewGuid().ToString();
          characterSheet.UserId = Guid.Parse(userId);
          dataStore.AddCharacterSheet(characterSheet);
          return dataStore.GetCharacterSheets(Guid.Parse(userId));
        });

      Field<ListGraphType<NonNullGraphType<CharacterSheetType>>>(
        "deleteCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          return dataStore.DeleteCharacterSheet(Guid.Parse(userId), Guid.Parse(characterSheetId));
        });
    }
  }
}
