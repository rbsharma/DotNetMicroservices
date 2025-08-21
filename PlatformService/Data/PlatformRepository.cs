using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
	{
		public PlatformRepository(IAppDbContext context) : base(context)
		{

		}
		public new async Task<IEnumerable<Platform>> GetAllAsync()
		{
			return await Context.Platforms.ToListAsync();
		}
		public async Task CreateAsync(Platform platform)
		{
			ArgumentNullException.ThrowIfNull(platform, nameof(platform));

			Context.Platforms.Add(platform);
			await Context.SaveChangesAsync();
		}

		public async Task<Platform?> GetByIdAsync(int id)
		{
			return await Context.Platforms.FirstOrDefaultAsync(p => p.Id == id);
		}
	}
}
