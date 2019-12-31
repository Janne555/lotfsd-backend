using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class CharacterSheetType : ObjectGraphType<CharacterSheet>
  {
    public CharacterSheetType()
    {
      Name = "CharacterSheet";
      Field<IdGraphType>("Id");
      Field(x => x.Name);
      Field(x => x.Owner);
      Field<AttributesType>("Attributes");
    }
  }

  public class AttributesType : ObjectGraphType<Attributes>
  {
    public AttributesType()
    {
      Name = "Attributes";
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
    }
  }
}