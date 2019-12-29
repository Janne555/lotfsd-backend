using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace LotfsdAPI.Models
{
  public class CharacterSheet
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string Owner { get; set; }
  }
}