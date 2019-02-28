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
	class SubscribeInfoCommand : ICommand
	{
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public SubscribeInfoCommand(IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var loggerId = long.Parse(queryRequest.Query.GetQueryParam("id"));

			var logger = _loggerRepository.FindById(loggerId);

			if (logger.IsNullOrEmpty())
				throw new KeyNotFoundException(nameof(logger));

			var res = await _telegramBot.EditMessageAsync(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new SubscribeInfoMessageTemplate(logger.Name, logger.Exceptions?.Count() ?? 0));

			res.EnsureSuccessStatusCode();
		}
	}
}
