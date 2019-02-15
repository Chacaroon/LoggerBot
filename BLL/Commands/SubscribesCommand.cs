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
			if (!(request is IQueryRequest))
				throw new InvalidCastException(nameof(request));

			var apps = _userRepository
				.GetAll(u => u.ChatId == request.ChatId)
				.First()
				.UserApps
				.Where(ua => ua.IsSubscriber)
				.Select(ua => ua.App);

			var appsMarkup = new InlineKeyboardMarkup();

			foreach (var app in apps)
			{
				appsMarkup.AddRow(
					new InlineKeyboardButton(
						app.Name,
						callbackData: $"subscribeInfo:id={app.Id}"));
			}

			var queryRequest = (IQueryRequest)request;

			var res = await _telegramBot.EditMessageAsync(
				request.ChatId,
				queryRequest.MessageId,
				new SubscribesMessageTemplate(appsMarkup));

			res.EnsureSuccessStatusCode();
		}
	}
}
