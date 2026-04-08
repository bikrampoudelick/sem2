using L3C1WebAPI.Data.Entities;
using L3C1WebAPI.Dtos.Request;
using L3C1WebAPI.Services.Implementations;
using L3C1WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L3C1WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModulesController(IModuleService moduleService ) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> AddModule(ModuleCreateDto moduleDto)
		{
			var response = await moduleService.AddModuleAsync(moduleDto);
			return Ok(response);
		}
	}
}
