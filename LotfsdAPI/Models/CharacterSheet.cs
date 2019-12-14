using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LotfsdAPI.Models
{
    public class CharacterSheet
    {
        [BsonID]
        [BsonRepresentation(BsonType.ObjectID)]
        public string Id { get; set; }


    }
}