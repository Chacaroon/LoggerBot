using BLL.MessageTemplates;
using DAL.Models;
using SharedKernel.BLL.Interfaces.Commands;
using SharedKernel.BLL.Interfaces.Models;
using SharedKernel.DAL.Interfaces;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApi;

namespace BLL.Commands
{
	class SubscribeInfoCommand : BaseCommand, ICommand
	{
		private IRepository<Logger> _loggerRepository;

		public SubscribeInfoCommand(IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
			: base(telegramBot)
		{
			_loggerRepository = loggerRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var loggerId = long.Parse(queryRequest.Query.GetQueryParam("id"));

			var logger = _loggerRepository.FindById(loggerId);

			if (logger.IsNullOrEmpty())
				throw new KeyNotFoundException(nameof(logger));

			await SendResponse(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new SubscribeInfoMessageTemplate(logger.Name, logger.Exceptions?.Count() ?? 0));
		}
	}
}
