using Microsoft.Extensions.DependencyInjection;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.Extensions;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.IoC
{
	public class CommandBootstrapper
	{
		public static void Bootstrap(Container container)
		{
			//Assembly.GetExecutingAssembly().GetTypes()
			//	.Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
			//	.Select(t => services.AddTransient(typeof(ICommand), t))
			//	.Count();

			container.Collection.Register(typeof(ICommand), Assembly.GetExecutingAssembly());
		}
	}
}
