using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using Lotfsd.Data.Models;
using MongoDB.Bson;

namespace Lotfsd.Data
{
  public class CharacterSheetService
  {
    private readonly IMongoCollection<CharacterSheet> _characterSheets;

    public CharacterSheetService(MongoService mongoService, IDatabaseSettings settings)
    {
      _characterSheets = mongoService.GetCollection<CharacterSheet>(settings.CharacterSheetCollectionName);
    }

    public async Task<List<CharacterSheet>> Get(string userId)
    {
      var characters = await _characterSheets.FindAsync(cs => cs.Owner == userId);
      return await characters.ToListAsync();
    }

    public async Task<CharacterSheet> Get(string userId, string id)
    {
      var cursor = await _characterSheets.FindAsync(cs => cs.Id == id && cs.Owner == userId);
      return await cursor.FirstOrDefaultAsync();
    }

    public async Task<CharacterSheet> Create(CharacterSheet cs)
    {
      await _characterSheets.InsertOneAsync(cs);
      return cs;
    }

    public async Task<CharacterSheet> Replace(string userId, CharacterSheet cs, string id)
    {
      var options = new FindOneAndReplaceOptions<CharacterSheet>
      {
        ReturnDocument = ReturnDocument.After
      };

      var filter = new BsonDocument(new Dictionary<string, string>
      {
        { "Id", id },
        { "Owner", userId }
      });

      return await _characterSheets.FindOneAndReplaceAsync(cs => cs.Id == id, cs);
    }
  }
}