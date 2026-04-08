using L3C1WebAPI.Data;
using L3C1WebAPI.Data.Entities;
using L3C1WebAPI.Dtos;
using L3C1WebAPI.Dtos.Request;
using L3C1WebAPI.Services.Interfaces;

namespace L3C1WebAPI.Services.Implementations
{
	public class ModuleService(AppDbContext dbContext) : IModuleService
	{
		public async Task<ApiResponse<Module>> AddModuleAsync(ModuleCreateDto moduleDto)
		{
			Module module = new Module
			{
				Title = moduleDto.Title,
				Credits = moduleDto.Credit,
				CourseId = moduleDto.CourseId,
			};

			//we have to check if courseId exist or not

			dbContext.Modules.Add(module);
			await dbContext.SaveChangesAsync();
			return new ApiResponse<Module>();
		}
	}
}
