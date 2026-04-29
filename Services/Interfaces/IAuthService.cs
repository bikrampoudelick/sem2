using L3C1WebAPI.Dtos.Request;
using L3C1WebAPI.Dtos.Response;

namespace L3C1WebAPI.Services.Interfaces
{
	public interface IAuthService
	{
		public Task<LoginResponse> LoginAsync(LoginDto loginDto);
	}
}
