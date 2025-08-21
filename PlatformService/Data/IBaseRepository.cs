namespace PlatformService.Data
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
	}
}
