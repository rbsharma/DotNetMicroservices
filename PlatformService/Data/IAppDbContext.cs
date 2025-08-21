using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlatformService.Models;

namespace PlatformService.Data
{
	public interface IAppDbContext
	{
		DbSet<Platform> Platforms { get; set; }

		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		EntityEntry Entry(object entity);
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
