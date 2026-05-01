using L3C1WebAPI.Data;
using L3C1WebAPI.Data.Entities;
using L3C1WebAPI.Dtos.Request;
using L3C1WebAPI.Dtos.Response;
using L3C1WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace L3C1WebAPI.Services.Implementations
{
	public class AuthService(
		SignInManager<User> signInManager,
		UserManager<User> userManager,
		JwtService jwtService,
		AppDbContext dbContext
		) : IAuthService
	{

		public async Task<RegisterResponse> RegisterStudent(RegisterStudentDto registerDto)
		{
			var transaction = await dbContext.Database.BeginTransactionAsync();
			var user = new User
			{
				UserName = registerDto.Email.Split("@").First(),
				Email = registerDto.Email,
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				PhoneNumber = registerDto.PhoneNumber,
			};
			var registerResult = await userManager.CreateAsync(user,registerDto.Password);
			if (!registerResult.Succeeded)
			{
				return new RegisterResponse
				{
					Success = false,
					Message = registerResult.ToString()
				};
			}

			var roleResult = await userManager.AddToRoleAsync(user, "Student");
			if (!roleResult.Succeeded)
			{
				await transaction.RollbackAsync();
				return new RegisterResponse
				{
					Success = false,
					Message = roleResult.ToString()
				};
			}

			await transaction.CommitAsync();
			return new RegisterResponse
			{
				Success = true,
				Message = "Successfully Registered"
			};

		}

		public async Task<LoginResponse> LoginAsync(LoginDto loginDto)
		{
			User? user = await userManager.FindByEmailAsync( loginDto.Email );
			if (user == null)
			{
				return new LoginResponse
				{
					Success = false,
					Message = "User not found"
				};
			}

			var signInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password,lockoutOnFailure:false);
			if (!signInResult.Succeeded)
			{
				return new LoginResponse
				{
					Success = false,
					Message = "Incorrect Password"
				};
			}
			return new LoginResponse
			{
				Success = true,
				Message = "Login Success",
				Token = jwtService.GenerateToken()
			};
			

		}
	}
}
