using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using TelegramBotApi;
using TelegramBotApi.Types;

namespace BLL.Commands
{
	class UndefinedCommand : BaseCommand, ICommand
	{
		public UndefinedCommand(ITelegramBot telegramBot)
			: base(telegramBot)
		{
		}

		public async Task Invoke(IRequest request)
		{
			await SendResponse(request.ChatId, new UndefinedCommandMessageTemplate());
		}
	}
}
