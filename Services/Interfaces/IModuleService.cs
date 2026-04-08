using L3C1WebAPI.Data.Entities;
using L3C1WebAPI.Dtos;
using L3C1WebAPI.Dtos.Request;

namespace L3C1WebAPI.Services.Interfaces
{
	public interface IModuleService
	{
		public Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleDto);

		//update
		//get
		//getbyid
		//delete
	}
}
