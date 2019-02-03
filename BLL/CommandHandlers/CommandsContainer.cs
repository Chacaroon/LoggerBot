using SharedKernel.BLL.Interfaces.CommandHandlers;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.CommandHandlers
{
	public class CommandsContainer : ICommandsContainer
	{
		private IEnumerable<ICommand> _commands;

		public CommandsContainer(IEnumerable<ICommand> commands)
		{
			_commands = commands;
		}

		public ICommand GetCommandHandler(string command)
		{
			return _commands
				.Where(c => c.GetType().Name.IsMatch($"(?i){command}command"))
				.FirstOrDefault();
		}
	}
}
