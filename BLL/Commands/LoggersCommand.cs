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
using TelegramBotApi.Types.ReplyMarkup;

namespace BLL.Commands
{
	class LoggersCommand : BaseCommand, ICommand
	{
		private IRepository<ApplicationUser> _userRepository;

		public LoggersCommand(
			ITelegramBot telegramBot,
			IRepository<ApplicationUser> userRepository)
			: base(telegramBot)
		{
			_userRepository = userRepository;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var loggers = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.SelectMany(u => u.UserLoggers)
				.Where(ua => !ua.IsSubscriber)
				.Select(ua => ua.Logger);

			var loggersMarkup = new InlineKeyboardMarkup();

			foreach (var logger in loggers)
			{
				loggersMarkup.AddRow(
					new InlineKeyboardButton(
						logger.Name,
						callbackData: $"loggerInfo:id={logger.Id}"));
			}

			await SendResponse(
				request.ChatId,
				queryRequest.MessageId,
				new LoggersMessageTemplate(loggersMarkup));
		}
	}
}
