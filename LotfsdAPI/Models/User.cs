using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LotfsdAPI.Models
{
  public class User
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public string PasswordHash { get; set; }
  }
}