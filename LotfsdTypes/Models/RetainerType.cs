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
      Field(x => x.Position, nullable: true);
      Field(x => x.Class, nullable: true);
      Field(x => x.Level, nullable: true);
      Field(x => x.Hitpoints, nullable: true);
      Field(x => x.Wage, nullable: true);
      Field(x => x.Share, nullable: true);
    }
  }

  public class RetainerInputType : InputObjectGraphType<Retainer>
  {
    public RetainerInputType()
    {
      Name = "RetainerInput";
      Field(x => x.Name);
      Field(x => x.Position, nullable: true);
      Field(x => x.Class, nullable: true);
      Field(x => x.Level, nullable: true);
      Field(x => x.Hitpoints, nullable: true);
      Field(x => x.Wage, nullable: true);
      Field(x => x.Share, nullable: true);
    }
  }

  public class RetainerUpdateType : InputObjectGraphType<Retainer>
  {
    public RetainerUpdateType()
    {
      Name = "RetainerUpdate";
      Field(x => x.Name, nullable: true);
      Field(x => x.Position, nullable: true);
      Field(x => x.Class, nullable: true);
      Field(x => x.Level, nullable: true);
      Field(x => x.Hitpoints, nullable: true);
      Field(x => x.Wage, nullable: true);
      Field(x => x.Share, nullable: true);
    }
  }
}
