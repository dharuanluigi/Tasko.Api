namespace Tasko.Api.Repository.Entities
{
  public abstract class EntityBase
  {
    public Guid Id { get; }

    public DateTime CreatedAt { get; protected set; }

    public DateTime UpdatedAt { get; protected set; }

    protected EntityBase()
    {
      Id = Guid.NewGuid();
    }
  }
}