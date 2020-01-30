using System;
using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class ItemInstanceType : ObjectGraphType<ItemInstance>
  {
    public ItemInstanceType()
    {
      Name = "ItemInstance";
      Field(x => x.Guid).Name("Id");
      Field(x => x.Equipped);
      Field(x => x.ItemGuid).Name("ItemId");
    }
  }

  public class ItemInstanceInputType : InputObjectGraphType<ItemInstance>
  {
    public ItemInstanceInputType()
    {
      Name = "ItemInstanceInput";
      Field(x => x.Equipped);
      Field(x => x.ItemId);
    }
  }
}
