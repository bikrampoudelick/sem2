using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace L3C1WebAPI.Data.Entities
{
	public class Module
	{
		public int Id { get; set; }

		[StringLength(50)]
		public string Title { get; set; }
		public int Credits { get; set; }

		public int CourseId { get; set; }
		public Course? Course { get; set; } //Navigation Property
	}
}
