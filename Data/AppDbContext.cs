using L3C1WebAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace L3C1WebAPI.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Module> Modules { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<IdentityRole>().ToTable("Roles");

			SeedRoles(builder);
		}


		public void SeedRoles(ModelBuilder builder)
		{
			List<IdentityRole> identityRoles =
				[
					new IdentityRole{
						Id = "3489eee2-e301-47a4-93d1-632894187ab7",
						Name = "Admin",
						NormalizedName = "ADMIN",
						ConcurrencyStamp = Guid.NewGuid().ToString()
					},
					new IdentityRole{
						Id = "92667dc2-bc30-4cbb-a666-4ffb50f6238e",
						Name = "Instructor",
						NormalizedName = "INSTRUCTOR",
						ConcurrencyStamp = Guid.NewGuid().ToString()
					},
					new IdentityRole{
						Id = "7e1d6df1-aff7-4f9f-b805-123ff6bd09fe",
						Name = "Student",
						NormalizedName = "STUDENT",
						ConcurrencyStamp = Guid.NewGuid().ToString()
					}

				];

			builder.Entity<IdentityRole>().HasData(identityRoles);
		}
	}
}
