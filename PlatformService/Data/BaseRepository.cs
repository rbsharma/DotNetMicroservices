
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected readonly IAppDbContext Context;

		public BaseRepository(IAppDbContext _context)
		{
			Context = _context;
		}
		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}
	}
}
