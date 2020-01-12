using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GraphQL.Types;
using Lotfsd.Data.Models;
using System.Linq;

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

      //  TODO solve n+1
      Field<ListGraphType<EffectType>, List<Effect>>()
         .Name("Effects")
         .ResolveAsync(ctx =>
         {
           return lotfsdContext.Effects.Where(effect => effect.CharacterSheetId == ctx.Source.Id).ToListAsync();
         });

      Field<ListGraphType<RetainerType>, List<Retainer>>()
         .Name("Retainers")
         .ResolveAsync(ctx =>
         {
           return lotfsdContext.Retainers.Where(effect => effect.CharacterSheetId == ctx.Source.Id).ToListAsync();
         });

      Field<ListGraphType<PropertyType>, List<Property>>()
         .Name("Retainers")
         .ResolveAsync(ctx =>
         {
           return lotfsdContext.Properties.Where(effect => effect.CharacterSheetId == ctx.Source.Id).ToListAsync();
         });

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
        .Name("Effects");
      Field<ListGraphType<PropertyInputType>, List<Property>>()
        .Name("Effects");
    }
  }
}