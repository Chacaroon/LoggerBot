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
	class RemoveLoggerCommand : ICommand
	{
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public RemoveLoggerCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
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

			var res = await _telegramBot.EditMessageAsync(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new RemoveLoggerSuccessMessageTemplate());

			res.EnsureSuccessStatusCode();
		}

		private async Task ProcessNoAnswer(IQueryRequest queryRequest)
		{
			var res = await _telegramBot.EditMessageAsync(
				queryRequest.ChatId, 
				queryRequest.MessageId,
				new LoggerRemovingCanceledMessageTemplate());

			res.EnsureSuccessStatusCode();
		}
	}
}
