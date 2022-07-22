using Tasko.Api.Repository.Entities;
using Tasko.Api.Repository.Interfaces;

namespace Tasko.Api.Repository
{
  public class UserRepository : IRepository<User>
  {
    private readonly ApplicationDataContext _context;

    public UserRepository(ApplicationDataContext context)
    {
      _context = context;
    }

    public async Task CreateAsync(User user)
    {
      await _context.Users.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public Task Delete(User user)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(User user)
    {
      throw new NotImplementedException();
    }
  }
}