using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Shouldly;
using Tasko.Api.Repository;
using Tasko.Api.Repository.Entities;

namespace Tasko.Api.Tests.RepositoryTests
{
  public class UserRepositoryTest
  {
    [Fact]
    public async Task Should_create_when_valid_user_was_informed()
    {
      // var mockSet = Substitute.For<DbSet<User>>();
      // var mockContext = Substitute.For<ApplicationDataContext>();
      // mockContext.
      // mockContext.Users.Returns(mockSet);

      // var repo = new UserRepository(mockContext);

      // var user = new User("user", "user@emal.com");
      // await repo.CreateAsync(user).ShouldNotThrowAsync();
      var entities = new List<User>();
      var queryable = entities.AsQueryable();
      var mockSet = Substitute.For<DbSet<User>, IQueryable<User>>();

      // Query the set
      ((IQueryable<User>)mockSet).Provider.Returns(queryable.Provider);
      ((IQueryable<User>)mockSet).Expression.Returns(queryable.Expression);
      ((IQueryable<User>)mockSet).ElementType.Returns(queryable.ElementType);
      ((IQueryable<User>)mockSet).GetEnumerator().Returns(queryable.GetEnumerator());

      // Modify the set
      mockSet.When(set => set.Add(Arg.Any<User>())).Do(info => entities.Add(info.Arg<User>()));
      mockSet.When(set => set.Remove(Arg.Any<User>())).Do(info => entities.Remove(info.Arg<User>()));

      var dbContext = Substitute.For<ApplicationDataContext>();
      dbContext.Set<User>().Returns(mockSet);

      var repo = new UserRepository(dbContext);

      var user = new User("user", "user@emal.com");
      await repo.CreateAsync(user).ShouldNotThrowAsync();
    }

    [Fact]
    public async Task Should_delete_when_valid_user_was_informed()
    {
      Assert.False(true);
    }

    [Fact]
    public async Task Should_return_many_users()
    {
      Assert.False(true);
    }

    [Fact]
    public async Task Should_return_a_user_with_valid_id()
    {
      Assert.False(true);
    }

    [Fact]
    public async Task Should_update_when_valid_user_was_informed()
    {
      Assert.False(true);
    }
  }
}