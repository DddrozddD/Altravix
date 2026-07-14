using Altavix.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Altavix.Persistence.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(u=>u.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(u=>u.LastName).HasMaxLength(100).IsRequired();
        builder.Property(u=>u.Email).HasMaxLength(100).IsRequired();
        
    }
}