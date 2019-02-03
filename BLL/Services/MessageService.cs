using SharedKernel.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;

namespace BLL.Services
{
	public class MessageService : IMessageService
	{
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

		}

		private void ProcessAsText(Message message)
		{

		}
	}
}
