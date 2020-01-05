using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{

  public class CharacterSheetType<T> : ObjectGraphType<T> where T : ICharacterSheet
  {
    public CharacterSheetType()
    {
      Field(x => x.Id);
      Field(x => x.CharacterId);
    }
  }

  public class InfoType : CharacterSheetType<Info>
  {
    public InfoType()
    {
      Name = "Info";
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

  public class AttributeModifiersType : ObjectGraphType<AttributeModifiers>
  {
    public AttributeModifiersType()
    {
      Name = "AttributeModifiers";
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
    }
  }

  public class SavingThrowsType : ObjectGraphType<SavingThrows>
  {
    public SavingThrowsType()
    {
      Name = "SavingThrows";
      Field(x => x.Paralyze);
      Field(x => x.Poison);
      Field(x => x.BreathWeapon);
      Field(x => x.MagicalDevice);
      Field(x => x.Magic);
    }
  }

  public class CommonActivitiesType : ObjectGraphType<CommonActivities>
  {
    public CommonActivitiesType()
    {
      Name = "CommonActivities";
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

  public class WalletType : ObjectGraphType<Wallet>
  {
    public WalletType()
    {
      Name = "Wallet";
      Field(x => x.Copper);
      Field(x => x.Silver);
      Field(x => x.Gold);
    }
  }

  public class EffectType : ObjectGraphType<Effect>
  {
    public EffectType()
    {
      Name = "Effect";
      Field(x => x.Type);
      Field(x => x.Target);
      Field(x => x.Method);
      Field(x => x.Value);
    }
  }

  public class RetainerType : ObjectGraphType<Retainer>
  {
    public RetainerType()
    {
      Name = "Retainer";
      Field(x => x.Name);
      Field(x => x.Position);
      Field(x => x.Class);
      Field(x => x.Level);
      Field(x => x.Hitpoints);
      Field(x => x.Wage);
      Field(x => x.Share);
      Field(x => x.id);
    }
  }

  public class CombatOptionsType : ObjectGraphType<CombatOptions>
  {
    public CombatOptionsType()
    {
      Name = "CombatOptions";
      Field(x => x.Standard);
      Field(x => x.Parry);
      Field(x => x.improvedParry);
      Field(x => x.press);
      Field(x => x.defensive);
    }
  }
}