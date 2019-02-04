using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.DAL.Interfaces;
using SharedKernel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramLoggingService.IoC
{
	public static class RepositoryProvider
	{
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRepository<App>, AppRepository>();
			services.AddTransient<IRepository<User>, UserRepository>();
		}
	}
}
