using System;
using GraphQL.Types;

namespace LotfsdAPI.Models
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
