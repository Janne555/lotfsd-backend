using LotfsdAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LotfsdAPI.Services
{
  public class MongoService
  {
    private readonly IMongoDatabase _database;
    public MongoService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
      return _database.GetCollection<T>(collectionName);
    }
  }
}