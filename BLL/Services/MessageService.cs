using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
		private IEnumerable<ICommand> _commands;

		public MessageService(IEnumerable<ICommand> commands)
		{
			_commands = commands;
		}

		public void HandleMessage(Message message)
		{
			if (message.IsCommand())
			{
				ProcessAsCommand(message);
				return;
			}

			ProcessAsText(message);
		}

		private void ProcessAsCommand(Message message)
		{
			var command = _commands.GetCommand(message.GetCommand())
				?? _commands.GetCommand("undefined");

			command.Invoke(message);
		}

		private void ProcessAsText(Message message)
		{

		}
	}
}
