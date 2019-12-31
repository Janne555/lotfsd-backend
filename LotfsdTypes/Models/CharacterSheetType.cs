using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class CharacterSheetType : ObjectGraphType<CharacterSheet>
  {
    public CharacterSheetType()
    {
      Name = "CharacterSheet";
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Owner);
    }
  }
}