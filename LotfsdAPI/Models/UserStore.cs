using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LotfsdAPI.Models
{
  public class UserStore : IUserStore<User>
  {
    public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }

    public void Dispose()
    {
    }

    public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }

    public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
      user.NormalizedUserName = normalizedName;
      return Task.CompletedTask;
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
      user.UserName = userName;
      return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
      throw new System.NotImplementedException();
    }
  }
}