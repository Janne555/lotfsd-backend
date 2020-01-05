using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lotfsd.Data.Models
{
  public class CharacterSheet : ICharacterSheet
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string CharacterId { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string Owner { get; set; }
  }

  public class Info : CharacterSheet
  {
    public string Name { get; set; }
    public int Experience { get; set; }
    public string Class { get; set; }
    public string Race { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Alignment { get; set; }
    public string Player { get; set; }
    public int AttackBonus { get; set; }
    public int CurrentHp { get; set; }
    public int MaxHp { get; set; }
    public int SurpriseChance { get; set; }
  }

  public class Attributes : CharacterSheet
  {
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Strength { get; set; }
    public int Wisdom { get; set; }
  }

  public class AttributeModifiers : CharacterSheet
  {
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Strength { get; set; }
    public int Wisdom { get; set; }
  }

  public class SavingThrows : CharacterSheet
  {
    public int Paralyze { get; set; }
    public int Poison { get; set; }
    public int BreathWeapon { get; set; }
    public int MagicalDevice { get; set; }
    public int Magic { get; set; }
  }

  public class CommonActivities : CharacterSheet
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

  public class Wallet : CharacterSheet
  {
    public int Copper { get; set; }
    public int Silver { get; set; }
    public int Gold { get; set; }
  }

  public class Effect : CharacterSheet
  {
    public string Type { get; set; }
    public string Target { get; set; }
    public string Method { get; set; }
    public int Value { get; set; }
  }

  public class Retainer : CharacterSheet
  {
    public string Name { get; set; }
    public string Position { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int Hitpoints { get; set; }
    public int Wage { get; set; }
    public int Share { get; set; }
  }

  public class CombatOptions : CharacterSheet
  {
    public bool Standard { get; set; }
    public bool Parry { get; set; }
    public bool ImprovedParry { get; set; }
    public bool Press { get; set; }
    public bool Defensive { get; set; }
  }
}
