using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GraphQL.Types;
using Lotfsd.Data.Models;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Lotfsd.Types.Models
{

  public class CharacterSheetType : ObjectGraphType<CharacterSheet>
  {
    public CharacterSheetType(LotfsdContext lotfsdContext)
    {
      Name = "CharacterSheet";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Name);
      Field(x => x.Experience);
      Field(x => x.Class);
      Field(x => x.Race);
      Field(x => x.Age);
      Field(x => x.Gender);
      Field(x => x.Alignment);
      Field(x => x.AttackBonus);
      Field(x => x.CurrentHp);
      Field(x => x.MaxHp);
      Field(x => x.SurpriseChance);
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
      Field(x => x.Paralyze);
      Field(x => x.Poison);
      Field(x => x.BreathWeapon);
      Field(x => x.MagicalDevice);
      Field(x => x.Magic);
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
      Field(x => x.Copper);
      Field(x => x.Silver);
      Field(x => x.Gold);
      Field(x => x.Standard);
      Field(x => x.Parry);
      Field(x => x.ImprovedParry);
      Field(x => x.Press);
      Field(x => x.Defensive);
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<EffectType>>>, List<Effect>>("Effects");
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<RetainerType>>>, List<Retainer>>("Retainers");
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<PropertyType>>>, List<Property>>("Properties");
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<ItemInstanceType>>>, List<ItemInstance>>("Inventory");
      Field<NonNullGraphType<ListGraphType<NonNullGraphType<LanguageType>>>, List<Language>>("LanguagesList");
    }
  }

  public class CharacterSheetInputType : InputObjectGraphType<CharacterSheet>
  {
    public CharacterSheetInputType()
    {
      Name = "CharacterSheetInput";
      Field(x => x.Name);
      Field(x => x.Experience);
      Field(x => x.Class);
      Field(x => x.Race);
      Field(x => x.Age);
      Field(x => x.Gender);
      Field(x => x.Alignment);
      Field(x => x.AttackBonus);
      Field(x => x.CurrentHp);
      Field(x => x.MaxHp);
      Field(x => x.SurpriseChance);
      Field(x => x.Charisma);
      Field(x => x.Constitution);
      Field(x => x.Dexterity);
      Field(x => x.Intelligence);
      Field(x => x.Strength);
      Field(x => x.Wisdom);
      Field(x => x.Paralyze);
      Field(x => x.Poison);
      Field(x => x.BreathWeapon);
      Field(x => x.MagicalDevice);
      Field(x => x.Magic);
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
      Field(x => x.Copper);
      Field(x => x.Silver);
      Field(x => x.Gold);
      Field(x => x.Standard);
      Field(x => x.Parry);
      Field(x => x.ImprovedParry);
      Field(x => x.Press);
      Field(x => x.Defensive);
      Field<ListGraphType<EffectInputType>, List<Effect>>()
        .Name("Effects");
      Field<ListGraphType<RetainerInputType>, List<Retainer>>()
        .Name("Retainers");
      Field<ListGraphType<PropertyInputType>, List<Property>>()
        .Name("Properties");
      Field<ListGraphType<LanguageInputType>, List<Language>>()
        .Name("LanguagesList");
    }
  }

  public class CharacterSheetUpdateType : InputObjectGraphType<CharacterSheet>
  {
    public CharacterSheetUpdateType()
    {
      Name = "CharacterSheetUpdate";
      Field(x => x.Name, nullable: true);
      Field(x => x.Experience, nullable: true);
      Field(x => x.Class, nullable: true);
      Field(x => x.Race, nullable: true);
      Field(x => x.Age, nullable: true);
      Field(x => x.Gender, nullable: true);
      Field(x => x.Alignment, nullable: true);
      Field(x => x.AttackBonus, nullable: true);
      Field(x => x.CurrentHp, nullable: true);
      Field(x => x.MaxHp, nullable: true);
      Field(x => x.SurpriseChance, nullable: true);
      Field(x => x.Charisma, nullable: true);
      Field(x => x.Constitution, nullable: true);
      Field(x => x.Dexterity, nullable: true);
      Field(x => x.Intelligence, nullable: true);
      Field(x => x.Strength, nullable: true);
      Field(x => x.Wisdom, nullable: true);
      Field(x => x.Paralyze, nullable: true);
      Field(x => x.Poison, nullable: true);
      Field(x => x.BreathWeapon, nullable: true);
      Field(x => x.MagicalDevice, nullable: true);
      Field(x => x.Magic, nullable: true);
      Field(x => x.Architecture, nullable: true);
      Field(x => x.Bushcraft, nullable: true);
      Field(x => x.Climbing, nullable: true);
      Field(x => x.Languages, nullable: true);
      Field(x => x.OpenDoors, nullable: true);
      Field(x => x.Search, nullable: true);
      Field(x => x.SleightOfHand, nullable: true);
      Field(x => x.SneakAttack, nullable: true);
      Field(x => x.Stealth, nullable: true);
      Field(x => x.Tinkering, nullable: true);
      Field(x => x.Copper, nullable: true);
      Field(x => x.Silver, nullable: true);
      Field(x => x.Gold, nullable: true);
      Field(x => x.Standard, nullable: true);
      Field(x => x.Parry, nullable: true);
      Field(x => x.ImprovedParry, nullable: true);
      Field(x => x.Press, nullable: true);
      Field(x => x.Defensive, nullable: true);
    }
  }
}