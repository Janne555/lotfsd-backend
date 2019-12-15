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

    public async Task<List<CharacterSheet>> Get()
    {
      var characters = await _characterSheets.FindAsync(book => true);
      return await characters.ToListAsync();
    }

    public CharacterSheet Get(string id) =>
      _characterSheets.Find((cs => cs.Id == id)).FirstOrDefault();

    public CharacterSheet Create(CharacterSheet cs)
    {
      _characterSheets.InsertOne(cs);
      return cs;
    }
  }
}