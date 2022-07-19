using Microsoft.EntityFrameworkCore;
using Tasko.Api.Repository.Entities;
using Tasko.Api.Repository.Mappings;

namespace Tasko.Api.Repository
{
  public class ApplicationDataContext : DbContext
  {
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
    }
  }
}