using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lotfsd.Types.Models
{
  public class CharacterSheet
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string Owner { get; set; }

    //public Attributes Attributes { get; set; }
  }

  public class Attributes
  {
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Strength { get; set; }
    public int Wisdom { get; set; }
  }

  public class AttributeModifiers
  {
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Strength { get; set; }
    public int Wisdom { get; set; }
  }

  public class SavingThrows
  {
    public int Paralyze { get; set; }
    public int Poison { get; set; }
    public int BreathWeapon { get; set; }
    public int MagicalDevice { get; set; }
    public int Magic { get; set; }
  }

  public class CommonActivities
  {
    public int Architecture { get; set; }
    public int Bushcraft { get; set; }
    public int Climbing { get; set; }
    public int Languages { get; set; }
    public int OpenDoors { get; set; }
    public int Search { get; set; }
    public int SleightOfHand { get; set; }
    public int SneakAttack { get; set; }
    public int Stealth { get; set; }
    public int Tinkering { get; set; }
  }

  public class Wallet
  {
    public int Copper { get; set; }
    public int Silver { get; set; }
    public int Gold { get; set; }
  }
}