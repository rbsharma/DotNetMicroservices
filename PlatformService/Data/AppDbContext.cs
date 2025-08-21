using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class AppDbContext : DbContext, IAppDbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public virtual DbSet<Platform> Platforms { get; set; }

		public override EntityEntry Entry(object entity)
		{
			return base.Entry(entity);
		}

		public override DbSet<TEntity> Set<TEntity>() where TEntity : class
		{
			return base.Set<TEntity>();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
