using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class PropertyType : ObjectGraphType<Property>
  {
    public PropertyType()
    {
      Name = "Property";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Name);
      Field(x => x.Value);
      Field(x => x.Rent);
      Field(x => x.Location);
      Field(x => x.Description);
      Field<ListGraphType<ItemInstanceType>>("Inventory");
    }
  }

  public class PropertyInputType : InputObjectGraphType<Property>
  {
    public PropertyInputType()
    {
      Name = "PropertyInput";
      Field(x => x.Name);
      Field(x => x.Value, nullable: true);
      Field(x => x.Rent, nullable: true);
      Field(x => x.Location, nullable: true);
      Field(x => x.Description, nullable: true);
      Field<ListGraphType<ItemInstanceInputType>>("Inventory");
    }
  }
}
