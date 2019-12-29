using GraphQL.Types;
using LotfsdAPI.Services;

namespace LotfsdAPI.Models
{
  public class LotfsdQuery : ObjectGraphType
  {
    public LotfsdQuery(CharacterSheetService characterSheetService)
    {
      Field<CharacterSheetType>(
        "characterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => characterSheetService.Get(context.GetArgument<string>("id")));
    }
  }
}