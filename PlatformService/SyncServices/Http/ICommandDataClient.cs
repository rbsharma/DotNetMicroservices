using PlatformService.Dtos;

namespace PlatformService.SyncServices.Http
{
	public interface ICommandDataClient
	{
		Task SendPlatformToCommandServiceAsync(PlatformReadDto platform);
	}
}
