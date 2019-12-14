using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LotfsdAPI.Models
{
    public class CharacterSheet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }


    }
}