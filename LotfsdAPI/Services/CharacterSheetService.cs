using System.Collections.Generic;
using LotfsdAPI.Models;
using MongoDB.Driver;

namespace LotfsdAPI.Services
{
  public class CharacterSheetService
  {
    private readonly IMongoCollection<CharacterSheet> _characterSheets;

    public CharacterSheetService(MongoService mongoService, IDatabaseSettings settings)
    {
      _characterSheets = mongoService.GetCollection<CharacterSheet>(settings.CharacterSheetCollectionName);
    }

    public List<CharacterSheet> Get() =>
      _characterSheets.Find(book => true).ToList();

    public CharacterSheet Get(string id) =>
      _characterSheets.Find((cs => cs.Id == id)).FirstOrDefault();

    public CharacterSheet Create(CharacterSheet cs)
    {
      _characterSheets.InsertOne(cs);
      return cs;
    }
  }
}