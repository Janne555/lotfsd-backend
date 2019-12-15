using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LotfsdAPI.Services;

namespace LotfsdAPI.Models
{
  public class UserStore : IUserStore<User>, IUserPasswordStore<User>
  {

    private readonly UserService _userService;

    public UserStore(UserService userService)
    {
      _userService = userService;
    }
    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
      await _userService.CreateUserAsync(user, cancellationToken);
      return IdentityResult.Success;
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
      return _userService.FindUserAsync(userId);
    }

    public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
      return _userService.FindUserByUsernameAsync(normalizedUserName);
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.PasswordHash);
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.UserName);
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.PasswordHash != null);
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
      user.NormalizedUserName = normalizedName;
      return Task.CompletedTask;
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
      user.PasswordHash = passwordHash;
      return Task.CompletedTask;
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
      user.UserName = userName;
      return Task.CompletedTask;
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {

      await _userService.UpdateUserAsync(user, cancellationToken);
      return IdentityResult.Success;
    }
  }
}