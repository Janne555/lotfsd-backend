using Lotfsd.Data.Models;
using GraphQL.Types;

namespace Lotfsd.Types.Models
{
  public class CharacterSheetInputType : InputObjectGraphType<CharacterSheet>
  {
    public CharacterSheetInputType()
    {
      Name = "CharacterSheetInput";
      Field(x => x.Name);
    }
  }
}
