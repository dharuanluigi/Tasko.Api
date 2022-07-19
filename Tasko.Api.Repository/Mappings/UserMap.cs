using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasko.Api.Repository.Entities;

namespace Tasko.Api.Repository.Mappings
{
  internal class UserMap : IEntityTypeConfiguration<User>
  {
    private const string TABLE_NAME = "User";
    private const string DATETIME_DEFAULT_VALUE = "GETUTCDATE()";

    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
      .ToTable(TABLE_NAME);

      builder
      .HasKey(u => u.Id);

      builder
      .Property(u => u.Id)
      .ValueGeneratedOnAdd();

      builder
      .Property(u => u.Name)
      .IsRequired();

      builder
      .HasIndex(u => u.Email)
      .IsUnique();

      builder
      .Property(u => u.CreatedAt)
      .IsRequired()
      .HasDefaultValueSql(DATETIME_DEFAULT_VALUE);

      builder
      .Property(u => u.UpdatedAt)
      .IsRequired();
    }
  }
}