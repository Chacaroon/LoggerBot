using SharedKernel.BLL.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Extensions
{
	public static class GetCommandExtension
	{
		public static ICommand GetCommandOrDefault(this IEnumerable<ICommand> commands, string commandName)
		{
			var command = commands
				.Where(c => c.GetType().Name.IsMatch($"^(?i){commandName}command$"))
				.FirstOrDefault();

			if (command == null)
				return commands
				.Where(c => c.GetType().Name == "UndefinedCommand")
				.FirstOrDefault();

			return command;
		}

		public static ICommand GetErrorCommand(this IEnumerable<ICommand> commands)
		{
			return commands
				.Where(c => c.GetType().Name.IsMatch($"ErrorCommand"))
				.First();
		}
	}
}
