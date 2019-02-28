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
	class SubscribesCommand : ICommand
	{
		private IRepository<ApplicationUser> _userRepository;
		private ITelegramBot _telegramBot;

		public SubscribesCommand(
			IRepository<ApplicationUser> userRepository,
			ITelegramBot telegramBot)
		{
			_userRepository = userRepository;
			_telegramBot = telegramBot;
		}

		public async Task Invoke(IRequest request)
		{
			var queryRequest = (IQueryRequest)request;

			var loggers = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First()
				.UserLoggers
				.Where(ua => ua.IsSubscriber)
				.Select(ua => ua.Logger);

			var loggersMarkup = new InlineKeyboardMarkup();

			foreach (var logger in loggers)
			{
				loggersMarkup.AddRow(
					new InlineKeyboardButton(
						logger.Name,
						callbackData: $"subscribeInfo:id={logger.Id}"));
			}

			var res = await _telegramBot.EditMessageAsync(
				request.ChatId,
				queryRequest.MessageId,
				new SubscribesMessageTemplate(loggersMarkup));

			res.EnsureSuccessStatusCode();
		}
	}
}
