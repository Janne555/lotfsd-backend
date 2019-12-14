using System.Collections.Generic;
using LotfsdAPI.Models;
using MongoDB.Driver;

namespace LotfsdAPI.Services
{
  public class CharacterSheetService
  {
    private readonly IMongoCollection<CharacterSheet> _characterSheets;

    public CharacterSheetService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _characterSheets = database.GetCollection<CharacterSheet>(settings.CharacterSheetCollectionName);
    }

    public List<CharacterSheet> Get() =>
      _characterSheets.Find(book => true).ToList();

    public CharacterSheet Create(CharacterSheet cs)
    {
      _characterSheets.InsertOne(cs);
      return cs;
    }
  }
}