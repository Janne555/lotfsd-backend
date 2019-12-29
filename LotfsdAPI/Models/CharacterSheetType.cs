using System;
using GraphQL.Types;

namespace LotfsdAPI.Models
{
  public class CharacterSheetType : ObjectGraphType<CharacterSheet>
  {
    public CharacterSheetType()
    {
      Field(x => x.Id);
      Field(x => x.Name);
    }
  }
}