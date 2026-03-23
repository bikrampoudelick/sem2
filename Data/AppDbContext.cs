using L3C1WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace L3C1WebAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Module> Modules { get; set; }
	}
}
