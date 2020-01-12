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

      Field<CharacterSheetType>(
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
          return dataStore.AddCharacterSheet(characterSheet);
        });
    }
  }
}
