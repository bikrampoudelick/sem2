using L3C1WebAPI.Dtos.Request;
using L3C1WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L3C1WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(IAuthService authService) : ControllerBase
	{
		[HttpPost("register/student")]
		public void RegisterStudent(RegisterStudentDto registerStudentDto)
		{

		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var loginResponse =  await authService.LoginAsync(loginDto);
			return loginResponse.Success ? Ok(loginResponse) : Unauthorized(loginResponse);
		}
	}
}
