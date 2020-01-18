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

      Field<NonNullGraphType<CharacterSheetType>>(
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
          return characterSheet;
        });

      Field<ListGraphType<CharacterSheetType>>(
        "deleteCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          var characterSheetId = context.GetArgument<string>("id");
          return dataStore.DeleteCharacterSheet(Guid.Parse(userId), characterSheetId);
        });
      
      Field<NonNullGraphType<CharacterSheetType>>(
        "updateCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" },
          new QueryArgument<CharacterSheetUpdateType> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var characterSheet = context.GetArgument<dynamic>("characterSheet");
          var characterSheetId = context.GetArgument<string>("id");
          return dataStore.UpdateCharacterSheet(characterSheet, characterSheetId);
        });
    }
  }
}
