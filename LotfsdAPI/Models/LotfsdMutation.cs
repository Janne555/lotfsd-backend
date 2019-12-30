using GraphQL;
using GraphQL.Server.Transports.Subscriptions.Abstractions;
using GraphQL.Types;
using LotfsdAPI.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace LotfsdAPI.Models
{
  public class LotfsdMutation : ObjectGraphType
  {
    public LotfsdMutation(CharacterSheetService characterSheetService, IHttpContextAccessor httpContextAccessor)
    {
      Name = "Mutation";

      Field<CharacterSheetType>(
        "createCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CharacterSheetInputType>> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          var user = httpContextAccessor.HttpContext.User;
          characterSheet.Owner = user.FindFirst(ClaimTypes.Name).Value;
          return characterSheetService.Create(characterSheet);
        });
    }
  }
}