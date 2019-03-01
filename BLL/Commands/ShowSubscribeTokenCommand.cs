using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class ShowSubscribeTokenCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public ShowSubscribeTokenCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			string loggerId = queryRequest.Query.GetQueryParam("id");

			long id = long.Parse(loggerId);

			var token = _loggerRepository.FindById(id).SubscribeToken;

			await SendResponse(
				request.ChatId,
				new ShowSubscribeTokenMessageTemplate(token));
		}

		private async Task SendIncorrectTokenResponse(long chatId)
		{
			await SendResponse(
				chatId,
				new IncorrectSubscribeTokenMessageTemplate());
		}
	}
}
