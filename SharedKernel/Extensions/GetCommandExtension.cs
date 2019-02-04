using SharedKernel.BLL.Interfaces.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Extensions
{
	public static class GetCommandExtension
	{
		public static ICommand GetCommandHandler(this IEnumerable<ICommand> commands, string command)
		{
			return commands
				.Where(c => c.GetType().Name.IsMatch($"(?i){command}command"))
				.FirstOrDefault();
		}
	}
}
