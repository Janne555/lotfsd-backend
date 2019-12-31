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
      Field<AttributesInputType>("Attributes");
    }
  }

  public class AttributesInputType : InputObjectGraphType<Attributes>
  {
    public AttributesInputType()
    {
      Name = "AttributesInput";
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
    }
  }
}
