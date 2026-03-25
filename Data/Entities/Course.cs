using System.ComponentModel.DataAnnotations;

namespace L3C1WebAPI.Data.Entities
{
	public class Course
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = null!;

		public int DurationYears { get; set; }

		public List<Module> Modules { get; set; } = [];  //Navigation Property
	}
}
