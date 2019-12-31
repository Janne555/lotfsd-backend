using GraphQL;
using GraphQL.Server.Transports.Subscriptions.Abstractions;
using GraphQL.Types;
using LotfsdAPI.Services;
using System.Security.Claims;


namespace LotfsdAPI.Models
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
    }
  }
}