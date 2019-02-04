using SharedKernel.BLL.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;
using TelegramBotApi.Types;

namespace BLL.Commands
{
	class UndefinedCommand : ICommand
	{
		private ITelegramBot _telegramBot;

		public UndefinedCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		public void Invoke(Message message)
		{
			_telegramBot.SendMessageAsync(message.Chat.Id, "Command is not defined :(");
		}
	}
}
