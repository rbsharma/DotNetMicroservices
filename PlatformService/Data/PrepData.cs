using PlatformService.Models;

namespace PlatformService.Data
{
	public static class PrepData
	{
		public static async Task PrepPopulationAsync(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<IAppDbContext>();
				await SeedDataAsync(context);
			}
		}

		private static async Task SeedDataAsync(IAppDbContext context)
		{
			if (!context.Platforms.Any())
			{
				Console.WriteLine("Seeding Data...");
				context.Platforms.AddRange(
					new Platform { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
					new Platform { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
					new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
				);
				await context.SaveChangesAsync();
			}
			else
			{
				Console.WriteLine("Data already exists, skipping seeding.");
			}
		}
	}
}
