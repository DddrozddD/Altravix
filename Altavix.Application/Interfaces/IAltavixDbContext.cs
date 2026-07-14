using Altavix.Domain;
using Microsoft.EntityFrameworkCore;

namespace Altavix.Application.Interfaces;

public interface IAltavixDbContext
{
    DbSet<CategoryEntity>  Categories { get; }
    DbSet<ProductEntity>  Products { get; }
    DbSet<UserEntity>   Users { get; }
    DbSet<RoleEntity>   Roles { get; } 
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}