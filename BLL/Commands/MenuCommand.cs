using BLL.MessageTemplates;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class MenuCommand : BaseCommand, ICommand
	{
		public MenuCommand(ITelegramBot telegramBot)
			: base(telegramBot)
		{
		}

		public async Task Invoke(IRequest request)
		{
			if (request is ICommandRequest)
			{
				await SendResponse(
					request.ChatId,
					new MenuMessageTemplate());
			}

			if (request is IQueryRequest)
			{
				await SendResponse(
					request.ChatId,
					((IQueryRequest)request).MessageId,
					new MenuMessageTemplate());
			}
		}
	}
}
