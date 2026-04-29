using System.ComponentModel.DataAnnotations;

namespace L3C1WebAPI.Dtos.Request
{
	public class LoginDto
	{
		[Required,EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
