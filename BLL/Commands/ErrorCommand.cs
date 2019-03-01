using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using TelegramBotApi;

namespace BLL.Commands
{
	class ErrorCommand : BaseCommand, ICommand
	{
		public ErrorCommand(ITelegramBot telegramBot)
			: base(telegramBot)
		{
		}

		public async Task Invoke(IRequest request)
		{
			await SendResponse(
				request.ChatId,
				new ErrorMessageTemplate()
				);
		}
	}
}
