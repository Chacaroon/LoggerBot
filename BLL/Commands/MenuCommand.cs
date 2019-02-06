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
			var res = await SendOrUpdateMessage(
				request.ChatId,
				new MenuMessageTemplate(),
				request.MessageId);

			res.EnsureSuccessStatusCode();
		}

		private Task<HttpResponseMessage> SendOrUpdateMessage(
			long chatId,
			IMessageTemplate messageTemplate,
			long messageId = default)
		{
			if (messageId == default)
				return _telegramBot.SendMessageAsync(
					chatId,
					messageTemplate);

			return _telegramBot.EditMessageAsync(
				chatId,
				messageId,
				messageTemplate);
		}
	}
}
