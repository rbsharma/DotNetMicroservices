using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IPlatformRepository _platformRepository;

		public PlatformsController(IMapper mapper, IPlatformRepository platformRepository)
		{
			_mapper = mapper;
			_platformRepository = platformRepository;
		}

		[HttpGet]
		[ProducesResponseType<PlatformReadDto>(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetPlatforms()
		{
			var platforms = await _platformRepository.GetAllAsync();
			return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
		}

		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType<PlatformReadDto>(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetPlatformById(int id)
		{
			var platform = await _platformRepository.GetByIdAsync(id);
			if (platform == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<PlatformReadDto>(platform));
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType<PlatformReadDto>(StatusCodes.Status201Created)]
		public async Task<IActionResult> CreatePlatform([FromBody] PlatformCreateDto platformCreateDto)
		{
			if (platformCreateDto == null)
			{
				return BadRequest("Platform data is null.");
			}
			var platform = _mapper.Map<Platform>(platformCreateDto);
			await _platformRepository.CreateAsync(platform);

			var platformReadDto = _mapper.Map<PlatformReadDto>(platform);
			return CreatedAtAction(nameof(GetPlatformById), new { id = platformReadDto.Id }, platformReadDto);
		}
	}
}
