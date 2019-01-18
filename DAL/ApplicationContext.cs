using Microsoft.EntityFrameworkCore;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserApp>()
				.HasKey(ua => new { ua.UserId, ua.AppId });

			modelBuilder.Entity<UserApp>()
				.HasOne(ua => ua.User)
				.WithMany(u => u.UserApps)
				.HasForeignKey(ua => ua.UserId);

			modelBuilder.Entity<UserApp>()
				.HasOne(ua => ua.App)
				.WithMany(a => a.UserApps)
				.HasForeignKey(ua => ua.AppId);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<App> Apps { get; set; }
		public DbSet<ExceptionInfo> Exceptions { get; set; }
	}
}
