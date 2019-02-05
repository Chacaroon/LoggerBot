using BLL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Services;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TelegramBotApi.Types;
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Services
{
	public class CallbackQueryService : ICallbackQueryService
	{
		private IEnumerable<ICommand> _commands;

		public CallbackQueryService(IEnumerable<ICommand> commands)
		{
			_commands = commands;
		}

		public void HandleRequest(CallbackQuery callbackQuery)
		{
			var request = new Request(
				callbackQuery.Message.Chat.Id,
				callbackQuery.Data,
				callbackQuery.Message.Id);

			var command = _commands.GetCommand(request.Text)
				?? _commands.GetCommand("undefined");

			try
			{
				command.Invoke(request).Wait();
			}
			catch
			{
				// TODO: Handle errors
			}
		}
	}
}
