using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class CharacterSheetInputType<T> : InputObjectGraphType<T> where T : ICharacterSheet
  {
    public CharacterSheetInputType()
    {
      Field(x => x.Id);
      Field(x => x.CharacterId);
    }
  }

  public class InfoInputType : CharacterSheetInputType<Info>
  {
    public InfoInputType()
    {
      Name = "InfoInput";
      Field(x => x.Name);
      Field(x => x.Experience);
      Field(x => x.Class);
      Field(x => x.Race);
      Field(x => x.Age);
      Field(x => x.Gender);
      Field(x => x.Alignment);
      Field(x => x.Player);
      Field(x => x.AttackBonus);
      Field(x => x.CurrentHp);
      Field(x => x.MaxHp);
      Field(x => x.SurpriseChance);
    }
  }
  public class AttributesInputType : CharacterSheetInputType<Attributes>
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

  public class AttributeModifiersInputType : CharacterSheetInputType<AttributeModifiers>
  {
    public AttributeModifiersInputType()
    {
      Name = "AttributeModifiersInput";
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
    }
  }

  public class SavingThrowsInputType : CharacterSheetInputType<SavingThrows>
  {
    public SavingThrowsInputType()
    {
      Name = "SavingThrowsInput";
      Field(x => x.Paralyze);
      Field(x => x.Poison);
      Field(x => x.BreathWeapon);
      Field(x => x.MagicalDevice);
      Field(x => x.Magic);
    }
  }

  public class CommonActivitiesInputType : CharacterSheetInputType<CommonActivities>
  {
    public CommonActivitiesInputType()
    {
      Name = "CommonActivitiesInput";
      Field(x => x.Architecture);
      Field(x => x.Bushcraft);
      Field(x => x.Climbing);
      Field(x => x.Languages);
      Field(x => x.OpenDoors);
      Field(x => x.Search);
      Field(x => x.SleightOfHand);
      Field(x => x.SneakAttack);
      Field(x => x.Stealth);
      Field(x => x.Tinkering);
    }
  }

  public class WalletInputType : CharacterSheetInputType<Wallet>
  {
    public WalletInputType()
    {
      Name = "WalletInput";
      Field(x => x.Copper);
      Field(x => x.Silver);
      Field(x => x.Gold);
    }
  }

  public class EffectInputType : CharacterSheetInputType<Effect>
  {
    public EffectInputType()
    {
      Name = "EffectInput";
      Field(x => x.Type);
      Field(x => x.Target);
      Field(x => x.Method);
      Field(x => x.Value);
    }
  }

  public class RetainerInputType : CharacterSheetInputType<Retainer>
  {
    public RetainerInputType()
    {
      Name = "RetainerInput";
      Field(x => x.Name);
      Field(x => x.Position);
      Field(x => x.Class);
      Field(x => x.Level);
      Field(x => x.Hitpoints);
      Field(x => x.Wage);
      Field(x => x.Share);
      Field(x => x.Id);
    }
  }

  public class CombatOptionsInputType : CharacterSheetInputType<CombatOptions>
  {
    public CombatOptionsInputType()
    {
      Name = "CombatOptions";
      Field(x => x.Standard);
      Field(x => x.Parry);
      Field(x => x.ImprovedParry);
      Field(x => x.Press);
      Field(x => x.Defensive);
    }
  }
}