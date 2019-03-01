using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;
using TelegramBotApi.Types;

namespace BLL.Commands
{
	class LoggerInfoCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public LoggerInfoCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var id = long.Parse(queryRequest.Query.GetQueryParam("id"));

			var logger = _loggerRepository.FindById(id);

			await SendResponse(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new LoggerInfoMessageTemplate(logger.Name, logger.Exceptions?.Count() ?? 0, logger.Id));
		}
	}
}
