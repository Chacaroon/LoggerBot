using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IoC
{
	public static class RepositoryProvider
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRepository<App>, AppRepository>();
			services.AddTransient<IRepository<User>, UserRepository>();

			services.AddDbContext<ApplicationContext>();
		}
	}
}
