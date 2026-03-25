using L3C1WebAPI.Data;
using L3C1WebAPI.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace L3C1WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController(AppDbContext dbContext) : ControllerBase
	{
		//private AppDbContext dbContext;
		//public CoursesController(AppDbContext dbContext)
		//{
		//	this.dbContext = dbContext;
		//}

		[HttpPost]  
		public async Task<IActionResult> AddCourse(Course course)
		{
			dbContext.Courses.Add(course);
			await dbContext.SaveChangesAsync();
			return Ok("Successfully Created!");
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCourses()
		{
			var allCourses = await dbContext.Courses.ToListAsync();
			return Ok(allCourses);
		}

		[HttpGet("modules")]
		public async Task<IActionResult> GetAllCoursesWithModules()
		{
			var allCourses = await dbContext.Courses.Select(
					c => new { c.Id, c.Name, c.DurationYears,ModuleCount = c.Modules.Count,c.Modules }
				)
				.ToListAsync();
			return Ok(allCourses);
		}
	}
}
