using BLL.Markups;
using SharedKernel.BLL.Interfaces.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;
using TelegramBotApi.Types;

namespace BLL.CommandHandlers
{
	public class StartCommand : ICommand
	{
		private ITelegramBot _telegramBot;

		public StartCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		public void Invoke(Message message)
		{
			_telegramBot.SendMessageAsync(message.Chat.Id, 
				"Response to `/start`", 
				ParseMode.Markdown, 
				replyMarkup: new StartMarkup());
		}
	}
}
