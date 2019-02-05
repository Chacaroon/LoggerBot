using BLL.Markups;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;
using TelegramBotApi.Types;

namespace BLL.Commands
{
	class MenuCommand : ICommand
	{
		private ITelegramBot _telegramBot;
		
		public MenuCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				"Меню",
				replyMarkup: new MenuMarkup());

			res.EnsureSuccessStatusCode();
		}
	}
}
