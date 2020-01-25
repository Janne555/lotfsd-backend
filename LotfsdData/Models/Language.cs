using System;
namespace Lotfsd.Data.Models
{
  public class Language
  {
    public int Id { get; set; }
    public string Guid { get; set; }
    public string Name { get; set; }
    public bool Known { get; set; }

    public CharacterSheet CharacterSheet { get; set; }
    public int CharacterSheetId { get; set; }
  }
}
