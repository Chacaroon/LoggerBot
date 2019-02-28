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
	class LoggerInfoCommand : ICommand
	{
		private IRepository<Logger> _loggerRepository;
		private ITelegramBot _telegramBot;

		public LoggerInfoCommand(
			IRepository<Logger> loggerRepository,
			ITelegramBot telegramBot)
		{
			_loggerRepository = loggerRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var id = long.Parse(queryRequest.QueryParams["id"]);

			var logger = _loggerRepository.FindById(id);

			var res = await _telegramBot.EditMessageAsync(
				queryRequest.ChatId,
				queryRequest.MessageId,
				new LoggerInfoMessageTemplate(logger.Name, logger.Exceptions?.Count() ?? 0, logger.Id));

			res.EnsureSuccessStatusCode();
		}
	}
}
