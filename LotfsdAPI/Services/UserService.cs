using System.Threading;
using System;
using MongoDB.Driver;
using LotfsdAPI.Models;
using System.Threading.Tasks;

namespace LotfsdAPI.Services
{
  public class UserService
  {
    private readonly IMongoCollection<User> _users;

    public UserService(MongoService mongoService, IDatabaseSettings databaseSettings)
    {
      _users = mongoService.GetCollection<User>(databaseSettings.UserCollectionName);
      var options = new CreateIndexOptions() { Unique = true };
      var field = new StringFieldDefinition<User>("NormalizedUserName");
      var indexDefinition = new IndexKeysDefinitionBuilder<User>().Ascending(field);
      var indexModel = new CreateIndexModel<User>(indexDefinition, options);
      _users.Indexes.CreateOne(indexModel);
    }

    public async Task<User> FindUserAsync(string userId)
    {
      var cursor = await _users.FindAsync(u => u.Id == userId);
      return await cursor.FirstAsync();
    }

    public async Task<User> FindUserByUsernameAsync(string username)
    {
      var cursor = await _users.FindAsync(u => u.NormalizedUserName == username);
      var user = await cursor.FirstOrDefaultAsync();
      return user;
    }

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
    {
      await _users.InsertOneAsync(user, null, cancellationToken);
    }

    public async Task UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
      var filter = Builders<User>.Filter.Eq("Id", user.Id);
      var update = Builders<User>.Update.Set("PasswordHash", user.PasswordHash);
      await _users.UpdateOneAsync(filter, update, null, cancellationToken);
    }
  }
}