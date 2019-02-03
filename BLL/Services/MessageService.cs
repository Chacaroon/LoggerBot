using SharedKernel.BLL.Interfaces.CommandHandlers;
using SharedKernel.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
		private ICommandsContainer _commandsContainer;

		public MessageService(ICommandsContainer commandsContainer)
		{
			_commandsContainer = commandsContainer;
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
			=> _commandsContainer.GetCommandHandler(message.GetCommand()).Invoke(message);

		private void ProcessAsText(Message message)
		{

		}
	}
}
