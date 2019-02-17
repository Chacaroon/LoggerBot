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
	class UndefinedCommand : ICommand
	{
		private ITelegramBot _telegramBot;

		public UndefinedCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var res = await _telegramBot.SendMessageAsync(request.ChatId, "Command is not defined :(");

			res.EnsureSuccessStatusCode();
		}
	}
}
