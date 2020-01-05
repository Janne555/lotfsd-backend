using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lotfsd.Data.Models
{
  public interface ICharacterSheet
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string CharacterId { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string Owner { get; set; }
  }
}
