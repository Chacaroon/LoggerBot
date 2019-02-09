using BLL.MessageTemplates;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;
using TelegramBotApi.Types.Abstraction;

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
			HttpResponseMessage res = default;

			if (request is ICommandRequest)
			{
				res = await _telegramBot.SendMessageAsync(
					request.ChatId,
					new MenuMessageTemplate());
			}

			if (request is IQueryRequest)
			{
				var temp = request as IQueryRequest;

				res = await _telegramBot.EditMessageAsync(
				request.ChatId,
				temp.MessageId,
				new MenuMessageTemplate());
			}
			
			res.EnsureSuccessStatusCode();
		}
	}
}
