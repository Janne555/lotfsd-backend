using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class ItemInstanceType : ObjectGraphType<ItemInstance>
  {
    public ItemInstanceType()
    {
      Name = "ItemInstance";
      Field(x => x.ItemId);
      Field(x => x.Id);
      Field(x => x.Equipped);
    }
  }

  public class ItemInstanceInputType : InputObjectGraphType<ItemInstance>
  {
    public ItemInstanceInputType()
    {
      Name = "ItemInstanceInput";
      Field(x => x.ItemId);
      Field(x => x.Id);
      Field(x => x.Equipped);
    }
  }
}
