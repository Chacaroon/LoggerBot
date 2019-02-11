using Microsoft.EntityFrameworkCore;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DAL
{
	public class ApplicationContext : DbContext
	{
		private IConfiguration _configuration;

		public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
			: base(options)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
		}

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

		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<App> Apps { get; set; }
		public DbSet<ExceptionInfo> Exceptions { get; set; }
		public DbSet<ChatState> ChatStates { get; set; }
	}
}
