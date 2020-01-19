using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class ItemType : ObjectGraphType<Item>
  {
    public ItemType()
    {
      Name = "Item";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Name);
      Field(x => x.EncumbrancePoints);
      Field(x => x.StackSize);
      Field(x => x.Encumbrance);
      Field(x => x.Description);
      Field(x => x.Type);
      Field(x => x.BaseArmorClass);
      Field(x => x.Damage);
      Field(x => x.AttackBonus);
      Field(x => x.RangeShort);
      Field(x => x.RangeMedium);
      Field(x => x.RangeLong);
      Field<ListGraphType<ItemEffectType>>("Effects");
    }
  }

  public class ItemInputType : InputObjectGraphType<Item>
  {
    public ItemInputType()
    {
      Name = "ItemInput";
      Field(x => x.Name);
      Field(x => x.EncumbrancePoints);
      Field(x => x.StackSize);
      Field(x => x.Encumbrance, nullable: true);
      Field(x => x.Description);
      Field(x => x.Type);
      Field(x => x.BaseArmorClass, nullable: true);
      Field(x => x.Damage, nullable: true);
      Field(x => x.AttackBonus, nullable: true);
      Field(x => x.RangeShort, nullable: true);
      Field(x => x.RangeMedium, nullable: true);
      Field(x => x.RangeLong, nullable: true);
      Field<ListGraphType<ItemEffectInputType>>("Effects");
    }
  }
}
