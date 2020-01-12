using System.Linq;
using GraphQL.Types;
using Lotfsd.Data.Models;
using Lotfsd.Types.Models;
using Microsoft.EntityFrameworkCore;
namespace Lotfsd.Types
{
  public class LotfsdQuery : ObjectGraphType
  {

    public LotfsdQuery(LotfsdContext lotfsdContext)
    {
      Name = "Query";
      Field<ListGraphType<CharacterSheetType>>(
        "CharacterSheets",
        resolve: context => lotfsdContext.CharacterSheets.ToListAsync());

      Field<CharacterSheetType>(
        "CharacterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          return lotfsdContext.CharacterSheets.Where(x => x.Guid.Equals(id)).FirstOrDefaultAsync();
        });
    }
  }
}