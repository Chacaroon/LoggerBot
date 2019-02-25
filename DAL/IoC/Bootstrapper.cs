using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.DAL.Interfaces;
using SimpleInjector;
using System;

namespace DAL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(Container container)
		{
			container.Register<IRepository<Logger>, LoggerRepository>(Lifestyle.Transient);
			container.Register<IRepository<ApplicationUser>, UserRepository>(Lifestyle.Transient);

			container.Register<Action<IServiceCollection, IConfiguration>>(() => (services, config) => 
				services.AddDbContext<ApplicationContext>(options => 
					options.UseSqlServer(config.GetConnectionString("DefaultConnection"))));
		}
	}
}
