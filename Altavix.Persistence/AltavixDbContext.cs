using Altavix.Application.Interfaces;
using Altavix.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Altavix.Persistence;

public class AltavixDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>, IAltavixDbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }

    public AltavixDbContext(DbContextOptions<AltavixDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // This line automatically applies all our configurations (ProductConfiguration, UserConfiguration, etc.)
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}