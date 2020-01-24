using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class ItemEffectType : ObjectGraphType<ItemEffect>
  {
    public ItemEffectType()
    {
      Name = "ItemEffect";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Method);
      Field(x => x.Target);
      Field(x => x.Value);
      Field(x => x.Type);
    }
  }

  public class ItemEffectInputType : InputObjectGraphType<ItemEffect>
  {
    public ItemEffectInputType()
    {
      Name = "ItemEffectInput";
      Field(x => x.Method);
      Field(x => x.Target);
      Field(x => x.Value);
      Field(x => x.Type);
    }
  }
}
