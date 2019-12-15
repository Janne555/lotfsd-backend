using System.Collections.Generic;
using LotfsdAPI.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace LotfsdAPI.Services
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
      var cursor = await _characterSheets.FindAsync((cs => cs.Id == id));
      return await cursor.FirstOrDefaultAsync();
    }

    public async Task<CharacterSheet> Create(CharacterSheet cs)
    {
      await _characterSheets.InsertOneAsync(cs);
      return cs;
    }
  }
}