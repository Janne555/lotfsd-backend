using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{

  public class RetainerType : ObjectGraphType<Retainer>
  {
    public RetainerType()
    {
      Name = "Retainer";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Name);
      Field(x => x.Position);
      Field(x => x.Class);
      Field(x => x.Level);
      Field(x => x.Hitpoints);
      Field(x => x.Wage);
      Field(x => x.Share);
    }
  }

  public class RetainerInputType : InputObjectGraphType<Retainer>
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
    }
  }
}
