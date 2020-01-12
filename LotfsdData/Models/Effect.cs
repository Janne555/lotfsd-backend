using System;
namespace Lotfsd.Data.Models
{
  public class Effect
  {
    public int Id { get; set; }
    public string Guid { get; set; }
    public string Type { get; set; }
    public string Target { get; set; }
    public string Method { get; set; }
    public int Value { get; set; }

    public CharacterSheet CharacterSheet { get; set; }
    public int CharacterSheetId { get; set; }
  }
}
