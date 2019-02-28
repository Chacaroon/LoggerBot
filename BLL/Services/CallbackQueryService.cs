using BLL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi;
using TelegramBotApi.Types;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Services
{
	public class CallbackQueryService : ICallbackQueryService
	{
		private IEnumerable<ICommand> _commands;
		private ITelegramBot _telegramBot;

		public CallbackQueryService(
			IEnumerable<ICommand> commands,
			ITelegramBot telegramBot)
		{
			_commands = commands;
			_telegramBot = telegramBot;
		}

		public void HandleRequest(CallbackQuery callbackQuery)
		{
			var request = new QueryRequest(
				callbackQuery.Message.Chat.Id,
				callbackQuery.Message.Id,
				callbackQuery.Data);

			var command = _commands.GetCommandOrDefault(request.Query.GetCommand());

			try
			{
				command.Invoke(request).Wait();
			}
			catch
			{
				_commands.GetErrorCommand().Invoke(request).Wait();
			}
			finally
			{
				_telegramBot.AnswerCallbackQuery(callbackQuery.Id).Wait();
			}
		}
	}
}
