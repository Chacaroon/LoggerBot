using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.MessageTemplates;
using BLL.Models;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using TelegramBotApi;

namespace BLL.Commands
{
	class RemoveLoggerCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public RemoveLoggerCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var answer = bool.Parse(queryRequest.Query.GetQueryParam("answer"));

			if (answer)
				await ProcessYesAnswer(queryRequest);
			else
				await ProcessNoAnswer(queryRequest);
		}

		private async Task ProcessYesAnswer(IQueryRequest queryRequest)
		{
			var loggerId = long.Parse(queryRequest.Query.GetQueryParam("id"));

			_loggerRepository.DeleteById(loggerId);

			await SendResponse(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new RemoveLoggerSuccessMessageTemplate());
		}

		private async Task ProcessNoAnswer(IQueryRequest queryRequest)
		{
			await SendResponse(
				queryRequest.ChatId, 
				queryRequest.MessageId,
				new LoggerRemovingCanceledMessageTemplate());
		}
	}
}
