using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;
using TelegramBotApi.Types.Abstraction;

namespace BLL
{
	public abstract class BaseCommand
	{
		private ITelegramBot _telegramBot;

		public BaseCommand(ITelegramBot telegramBot)
		{
			_telegramBot = telegramBot;
		}

		protected async Task SendResponse(
			long chatId,
			IMessageTemplate messageTemplate)
		{
			var res = await _telegramBot.SendMessageAsync(
				chatId,
				messageTemplate);

			res.EnsureSuccessStatusCode();
		}

		protected async Task SendResponse(
			long chatId,
			long messageId,
			IMessageTemplate messageTemplate)
		{
			var res = await _telegramBot.EditMessageAsync(
				chatId,
				messageId,
				messageTemplate);

			res.EnsureSuccessStatusCode();
		}
	}
}
