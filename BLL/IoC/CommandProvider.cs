using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.IoC
{
	public static class CommandProvider
	{
		public static void AddCommands(this IServiceCollection services)
		{
			var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
				.Where(t => t.Name.IsMatch(@"(?i)\w*command"));

			foreach (Type t in commandTypes)
				services.AddTransient(typeof(ICommand), t);
		}
	}
}
