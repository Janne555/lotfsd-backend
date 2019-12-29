using GraphQL.Types;
using LotfsdAPI.Services;
using System.Security.Claims;

namespace LotfsdAPI.Models
{
  public class LotfsdQuery : ObjectGraphType
  {
    public LotfsdQuery(CharacterSheetService characterSheetService)
    {
      Field<CharacterSheetType>(
        "characterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => characterSheetService.GetGraphQL(context.GetArgument<string>("id")));

      Field<ListGraphType<CharacterSheetType>>(
        "characterSheets",
        resolve: context => characterSheetService.GetAll());

    }
  }
}