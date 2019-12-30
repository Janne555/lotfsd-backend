using GraphQL.Types;
using LotfsdAPI.Services;

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
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          return characterSheetService.Create(characterSheet);
        });
    }
  }
}