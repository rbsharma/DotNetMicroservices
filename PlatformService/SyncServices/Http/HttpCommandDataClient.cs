using PlatformService.Dtos;

namespace PlatformService.SyncServices.Http
{
	public class HttpCommandDataClient : ICommandDataClient
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}
		public async Task SendPlatformToCommandServiceAsync(PlatformReadDto platform)
		{
			var commandServiceEndpoint = _configuration["CommandServiceEndpoint"];
			var response = await _httpClient.PostAsJsonAsync(commandServiceEndpoint, platform);

			if(response.IsSuccessStatusCode)
			{
				Console.WriteLine("--> Sync POST to CommandService was OK!");
			}
			else
			{
				Console.WriteLine($"--> Sync POST to CommandService failed. Status Code: {response.StatusCode}");
			}
		}
	}
}
