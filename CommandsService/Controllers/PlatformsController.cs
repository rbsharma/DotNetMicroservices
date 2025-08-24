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

		[HttpPost]
		public IActionResult TestInboundConnection()
		{
			Console.WriteLine($"--> Incoming request to {nameof(CommandsService)}.{nameof(PlatformsController)}.{nameof(TestInboundConnection)}.");
			return Ok(new { Message = "Inbound test of PlatformsController!" });
		}
	}
}
