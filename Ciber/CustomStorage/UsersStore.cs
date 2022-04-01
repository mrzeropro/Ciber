using Ciber.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ciber.CustomStorage
{
  public class UsersStore : 
    IUserStore<User>,
    IUserPasswordStore<User>,
    IUserLoginStore<User>,
    IUserRoleStore<User>
  {
    private readonly CiberdbContext _context;
    public UsersStore(
      CiberdbContext context)
    {
      _context = context;
    }

    public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task AddToRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IdentityResult> CreateAsync(Role user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(Role user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
    }

    public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
      return Task.FromResult(_context.User.FirstOrDefault(u => u.Id.ToString() == userId));
    }

    public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
      return Task.FromResult(_context.User.FirstOrDefault(user => user.Username == normalizedUserName));
    }

    public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(Role user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.Password);
    }

    public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
      return Task.Run(() =>
      {
        var roleID = user.RoleId;
        var result = _context.Role.Where(role => role.Id == roleID).Select(role => role.Role1).ToList();
        return result as IList<string>;
      });
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.Id.ToString());
    }

    public Task<string> GetUserIdAsync(Role user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
      return Task.FromResult(user.Username);
    }

    public Task<string> GetUserNameAsync(Role user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IList<Role>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(Role user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(Role user, string normalizedName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task SetUserNameAsync(Role user, string userName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    Task<IList<User>> IUserRoleStore<User>.GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
