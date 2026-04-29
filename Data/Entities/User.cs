using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace L3C1WebAPI.Data.Entities
{
	public class User : IdentityUser
	{
		[Required, StringLength(50)]
		public string FirstName { get; set; } = null!;

		[Required, StringLength(50)]
		public string LastName { get; set; } = null!;
	}
}
