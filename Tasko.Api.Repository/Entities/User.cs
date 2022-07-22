namespace Tasko.Api.Repository.Entities
{
  public class User : EntityBase
  {
    public string Name { get; }

    public string Email { get; }

    public User(string name, string email)
    {
      Name = name;
      Email = email;
      CreatedAt = DateTime.UtcNow;
    }
  }
}