using BLL.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces.CommandHandlers;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TelegramLoggingService.IoC
{
	public static class CommandsProvider
	{
		public static void AddCommands(this IServiceCollection services)
		{
			var commandType = Assembly.Load("BLL").GetTypes()
				.Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
				.Where(t => t.Name.IsMatch(@"(?i)\w*command"));

			foreach (Type t in commandType)
				services.AddTransient(typeof(ICommand), t);
		}
	}
}
