using L3C1WebAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace L3C1WebAPI.Dtos.Request
{
	public class ModuleCreateDto
	{
		[Required]
		public string Title { get; set; }

		[Range(10,30)]
		public int Credit { get; set; }

		public int CourseId { get; set; }

		
	}
}
