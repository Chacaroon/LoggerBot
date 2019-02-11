using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class ErrorCommand : ICommand
	{
		private ITelegramBot _telegramBot;

		public ErrorCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var res = await _telegramBot.SendMessageAsync(
				request.ChatId,
				"При выполнении запроса возникла ошибка");

			res.EnsureSuccessStatusCode();
		}
	}
}
