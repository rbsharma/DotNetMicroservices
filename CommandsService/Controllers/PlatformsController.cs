using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
	[Route("api/c/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		public PlatformsController()
		{
			
		}

		[HttpGet]
		public async Task<IActionResult> GetPlatforms()
		{
			Console.WriteLine($"--> Incoming request to {nameof(CommandsService)}.{nameof(PlatformsController)}.{nameof(GetPlatforms)}.");
			return Ok(new { Message = "This is the PlatformsController!" });
		}
	}
}
