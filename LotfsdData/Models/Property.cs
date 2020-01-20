namespace Lotfsd.Data.Models
{
  public class Property
  {
    public int Id { get; set; }
    public string Guid { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Rent { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public ItemInstance Inventory { get; set; }

    public CharacterSheet CharacterSheet { get; set; }
    public int CharacterSheetId { get; set; }
  }
}
