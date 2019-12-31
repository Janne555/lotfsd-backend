using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Lotfsd.Data.Models
{
  public class Property
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string Owner { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Rent { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public ItemInstance Inventory { get; set; }
  }
}
