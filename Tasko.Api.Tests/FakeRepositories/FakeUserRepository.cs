using Tasko.Api.Repository.Entities;
using Tasko.Api.Repository.Interfaces;

namespace Tasko.Api.Tests.FakeRepositories
{
  public class FakeUserRepository : IRepository<User>
  {
    public async Task CreateAsync(User item) => await Task.CompletedTask;

    public async Task Delete(User item) => await Task.CompletedTask;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await Task.Run(() => new List<User>
      {
        new User("User1", "emailUser1@email.com"),
        new User("User2", "emailUser2@email.com")
      });
    }

    public async Task<User> GetByIdAsync(Guid id) => await Task.Run(() => new User("User1", "emailUser1@email.com"));

    public async Task Update(User item) => await Task.CompletedTask;
  }
}