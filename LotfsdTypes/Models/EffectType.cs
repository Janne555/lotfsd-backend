using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class EffectType : ObjectGraphType<Effect>
  {
    public EffectType()
    {
      Name = "Effect";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Type);
      Field(x => x.Target);
      Field(x => x.Method);
      Field(x => x.Value);
    }
  }

  public class EffectInputType : InputObjectGraphType<Effect>
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
}
