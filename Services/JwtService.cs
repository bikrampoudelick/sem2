using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace L3C1WebAPI.Services
{
	public class JwtService(IConfiguration config)
	{
		public string GenerateToken()
		{
			string secretKey = config["Jwt:SecretKey"]!;
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

			var tokenObj = new JwtSecurityToken(
					issuer: config["Jwt:Issuer"],
					audience: config["Jwt:Audience"],
					claims: [],
					signingCredentials: signingCredentials,
					expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(config["Jwt:ExpiresInMinutes"]))
				);

			string token = new JwtSecurityTokenHandler().WriteToken(tokenObj);
			return token;

		}
	}
}
