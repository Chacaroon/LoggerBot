using SharedKernel.BLL.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedKernel.Extensions
{
	public static class GetCommandExtension
	{
		public static ICommand GetCommand(this IEnumerable<ICommand> commands, string command)
		{
			return commands
				.Where(c => c.GetType().Name.IsMatch($"(?i){command}command"))
				.FirstOrDefault();
		}
	}
}
