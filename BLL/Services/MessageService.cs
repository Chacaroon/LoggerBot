using SharedKernel.BLL.Interfaces.CommandHandlers;
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
			var command = _commands.GetCommandHandler(message.GetCommand())
				?? _commands.GetCommandHandler("undefined");

			command.Invoke(message);
		}

		private void ProcessAsText(Message message)
		{

		}
	}
}
