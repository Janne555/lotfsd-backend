using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using Lotfsd.Data.Models;

namespace Lotfsd.Data
{
  public class CharacterSheetService<T> where T : ICharacterSheet
  {
    private readonly IMongoCollection<T> _collection;

    public CharacterSheetService(MongoService mongoService, string collectionName)
    {
      _collection = mongoService.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> Get(string owner)
    {
      var characters = await _collection.FindAsync(cs => cs.Owner == owner);
      return await characters.ToListAsync();
    }

    public async Task<T> Get(string id, string owner)
    {
      var cursor = await _collection.FindAsync(cs => cs.Id == id && cs.Owner == owner);
      return await cursor.FirstOrDefaultAsync();
    }

    async public Task<T> Create(T doc)
    {
      await _collection.InsertOneAsync(doc);
      return doc;
    }

    public Task<T> Replace(string userId, T doc, string id)
    {
      var options = new FindOneAndReplaceOptions<T>
      {
        ReturnDocument = ReturnDocument.After
      };

      var filter = new BsonDocument(new Dictionary<string, string>
      {
        { "Id", id },
        { "Owner", userId }
      });

      return _collection.FindOneAndReplaceAsync(cs => cs.Id == id, doc);
    }
  }
}