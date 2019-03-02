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
		public ApplicationContext() { }
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserLogger>()
				.HasKey(ul => new { ul.UserId, ul.LoggerId });

			modelBuilder.Entity<UserLogger>()
				.HasOne(ul => ul.User)
				.WithMany(u => u.UserLoggers)
				.HasForeignKey(ul => ul.UserId);

			modelBuilder.Entity<UserLogger>()
				.HasOne(ul => ul.Logger)
				.WithMany(l => l.UserLoggers)
				.HasForeignKey(ul => ul.LoggerId);

			modelBuilder.Entity<ExceptionInfo>()
				.HasOne(ei => ei.Logger)
				.WithMany(l => l.Exceptions)
				.OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<Logger> Loggers { get; set; }
		public DbSet<ExceptionInfo> Exceptions { get; set; }
		public DbSet<ChatState> ChatStates { get; set; }
	}
}
